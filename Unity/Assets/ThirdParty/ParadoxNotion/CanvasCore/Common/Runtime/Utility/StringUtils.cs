﻿using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Text.RegularExpressions;

namespace ParadoxNotion
{

    ///Some common string utilities
    public static class StringUtils
    {

        public const string SPACE = " ";
        public const string ALPHABET = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public static readonly char[] CHAR_SPACE_ARRAY = new char[] { ' ' };
        private static Dictionary<string, string> splitCaseCache = new Dictionary<string, string>(StringComparer.Ordinal);

        ///Convert camelCase to words.
        public static string SplitCamelCase(this string s) {
            if ( string.IsNullOrEmpty(s) ) { return s; }

            string result;
            if ( splitCaseCache.TryGetValue(s, out result) ) {
                return result;
            }

            result = s;
            var underscoreIndex = result.IndexOf('_');
            if ( underscoreIndex <= 1 ) {
                result = result.Substring(underscoreIndex + 1);
            }
            result = Regex.Replace(result, "(?<=[a-z])([A-Z])", " $1").CapitalizeFirst().Trim();
            return splitCaseCache[s] = result;
        }

        ///Capitalize first letter
        public static string CapitalizeFirst(this string s) {
            if ( string.IsNullOrEmpty(s) ) { return s; }
            return s.First().ToString().ToUpper() + s.Substring(1);
        }

        ///Caps the length of a string to max length and adds "..." if more.
        public static string CapLength(this string s, int max) {
            if ( string.IsNullOrEmpty(s) || s.Length <= max || max <= 3 ) { return s; }
            var result = s.Substring(0, Mathf.Min(s.Length, max) - 3);
            result += "...";
            return result;
        }

        ///Gets only the capitals of the string trimmed.
        public static string GetCapitals(this string s) {
            if ( string.IsNullOrEmpty(s) ) {
                return string.Empty;
            }
            var result = "";
            foreach ( var c in s ) {
                if ( char.IsUpper(c) ) {
                    result += c.ToString();
                }
            }
            result = result.Trim();
            return result;
        }

        ///Formats input to error
        public static string FormatError(this string input) {
            return string.Format("<color=#ff6457>* {0} *</color>", input);
        }

        ///Returns the alphabet letter based on it's index.
        public static string GetAlphabetLetter(int index) {
            if ( index < 0 ) {
                return null;
            }

            if ( index >= ALPHABET.Length ) {
                return index.ToString();
            }

            return ALPHABET[index].ToString();
        }

        ///Get the string result within from to
        public static string GetStringWithinOuter(this string input, char from, char to) {
            var start = input.IndexOf(from) + 1;
            var end = input.LastIndexOf(to);
            if ( start < 0 || end < start ) { return null; }
            return input.Substring(start, end - start);
        }

        ///Get the string result within from to
        public static string GetStringWithinInner(this string input, char from, char to) {
            var end = input.IndexOf(to);
            var start = int.MinValue;
            for ( var i = 0; i < input.Length; i++ ) {
                if ( i > end ) { break; }
                if ( input[i] == from ) { start = i; }
            }
            start += 1;
            if ( start < 0 || end < start ) { return null; }
            return input.Substring(start, end - start);
        }

        ///Replace text within start and end chars based on provided processor
        public static string ReplaceWithin(this string text, char startChar, char endChar, System.Func<string, string> Process) {
            var s = text;
            var i = 0;
            while ( ( i = s.IndexOf(startChar, i) ) != -1 ) {
                var end = s.Substring(i + 1).IndexOf(endChar);
                var input = s.Substring(i + 1, end); //what's in the chars
                var output = s.Substring(i, end + 2); //what should be replaced (includes chars)
                var result = Process(input);
                s = s.Replace(output, result);
                i++;
            }

            return s;
        }

        ///Returns a simplistic matching score (0-1) vs leaf + optional category.
        ///Lower is better so can be used without invert in OrderBy.
        public static float ScoreSearchMatch(string input, string leafName, string categoryName = "") {

            if ( input == null || leafName == null ) return float.PositiveInfinity;
            if ( categoryName == null ) { categoryName = string.Empty; }

            input = input.ToUpper();
            var inputWords = input.Replace('.', ' ').Split(CHAR_SPACE_ARRAY, StringSplitOptions.RemoveEmptyEntries);
            if ( inputWords.Length == 0 ) {
                return 1;
            }

            leafName = leafName.ToUpper();
            var firstLeafWord = leafName.Split(CHAR_SPACE_ARRAY, StringSplitOptions.RemoveEmptyEntries)[0];
            leafName = leafName.Replace(" ", string.Empty);

            if ( input.LastOrDefault() == '.' ) {
                leafName = categoryName.ToUpper().Replace(" ", string.Empty);
            }

            //remember lower is better
            var score = 1f;

            if ( categoryName.Contains(inputWords[0]) ) {
                score *= 0.9f;
            }

            if ( firstLeafWord == inputWords[inputWords.Length - 1] ) {
                score *= 0.5f;
            }

            if ( leafName.StartsWith(inputWords[0]) ) {
                score *= 0.5f;
            }

            if ( leafName.StartsWith(inputWords[inputWords.Length - 1]) ) {
                score *= 0.5f;
            }

            return score;
        }

        ///Returns whether or not the input is valid for a search match vs the leaf + optional category.
        public static bool SearchMatch(string input, string leafName, string categoryName = "") {

            if ( input == null || leafName == null ) return false;
            if ( categoryName == null ) { categoryName = string.Empty; }

            if ( leafName.Length <= 1 && input.Length <= 2 ) {
                string alias = null; //usually only operator like searches are less than 2
                if ( ReflectionTools.op_CSharpAliases.TryGetValue(input, out alias) ) {
                    return alias == leafName;
                }
            }

            if ( input.Length <= 1 ) {
                return input == leafName;
            }

            //ignore case
            input = input.ToUpper();
            leafName = leafName.ToUpper().Replace(" ", string.Empty);
            categoryName = categoryName.ToUpper().Replace(" ", string.Empty);
            var fullPath = categoryName + "/" + leafName;

            //treat dot as spaces and split to words
            var words = input.Replace('.', ' ').Split(CHAR_SPACE_ARRAY, StringSplitOptions.RemoveEmptyEntries);
            if ( words.Length == 0 ) {
                return false;
            }

            //last input char check
            if ( input.LastOrDefault() == '.' ) {
                return categoryName.Contains(words[0]);
            }

            //check match for sequential occurency
            var leftover = fullPath;
            for ( var i = 0; i < words.Length; i++ ) {
                var word = words[i];

                if ( !leftover.Contains(word) ) {
                    return false;
                }

                leftover = leftover.Substring(leftover.IndexOf(word) + word.Length);
            }

            //last word should also be contained in leaf name regardless
            var lastWord = words[words.Length - 1];
            return leafName.Contains(lastWord);
        }

        ///A more complete ToString version
        public static string ToStringAdvanced(this object o) {

            if ( o == null || o.Equals(null) ) {
                return "NULL";
            }

            if ( o is string ) {
                return string.Format("\"{0}\"", (string)o);
            }

            if ( o is UnityEngine.Object ) {
                return ( o as UnityEngine.Object ).name;
            }

            var t = o.GetType();
            if ( t.RTIsSubclassOf(typeof(System.Enum)) ) {
                if ( t.RTIsDefined<System.FlagsAttribute>(true) ) {
                    var value = string.Empty;
                    var cnt = 0;
                    var list = System.Enum.GetValues(t);
                    for ( var i = 1; i < list.Length; i++ ) {
                        var e = list.GetValue(i);
                        if ( ( Convert.ToInt32(e) & Convert.ToInt32(o) ) == Convert.ToInt32(e) ) {
                            cnt++;
                            if ( value == string.Empty ) {
                                value = e.ToString();
                            } else {
                                value = "Mixed...";
                            }
                        }
                    }
                    if ( cnt == 0 ) {
                        return "Nothing";
                    }
                    if ( cnt == list.Length - 1 ) {
                        return "Everything";
                    }
                    return value;
                }
            }

            return o.ToString();
        }
    }
}
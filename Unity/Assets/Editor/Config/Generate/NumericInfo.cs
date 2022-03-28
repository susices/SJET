//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using Bright.Serialization;
using System.Collections.Generic;
using SimpleJSON;
using System;


namespace ET.ConfigEditor
{

[Serializable]
public sealed partial class NumericInfo :  Bright.Config.EditorBeanBase 
{
    public NumericInfo()
    {
            Name = "";
    }

    public override void LoadJson(SimpleJSON.JSONObject _json)
    {
        { 
            var _fieldJson = _json["name"];
            if (_fieldJson != null)
            {
                if(!_fieldJson.IsString) { throw new SerializationException(); }  Name = _fieldJson;
            }
        }
        
        { 
            var _fieldJson = _json["Base"];
            if (_fieldJson != null)
            {
                if(!_fieldJson.IsBoolean) { throw new SerializationException(); }  Base = _fieldJson;
            }
        }
        
        { 
            var _fieldJson = _json["Add"];
            if (_fieldJson != null)
            {
                if(!_fieldJson.IsBoolean) { throw new SerializationException(); }  Add = _fieldJson;
            }
        }
        
        { 
            var _fieldJson = _json["Pct"];
            if (_fieldJson != null)
            {
                if(!_fieldJson.IsBoolean) { throw new SerializationException(); }  Pct = _fieldJson;
            }
        }
        
        { 
            var _fieldJson = _json["FinalAdd"];
            if (_fieldJson != null)
            {
                if(!_fieldJson.IsBoolean) { throw new SerializationException(); }  FinalAdd = _fieldJson;
            }
        }
        
        { 
            var _fieldJson = _json["FinalPct"];
            if (_fieldJson != null)
            {
                if(!_fieldJson.IsBoolean) { throw new SerializationException(); }  FinalPct = _fieldJson;
            }
        }
        
    }

    public override void SaveJson(SimpleJSON.JSONObject _json)
    {
        _json["$type"] = "NumericInfo";
        {

            if (Name == null) { throw new System.ArgumentNullException(); }
            _json["name"] = new JSONString(Name);
        }
        {
            _json["Base"] = new JSONBool(Base);
        }
        {
            _json["Add"] = new JSONBool(Add);
        }
        {
            _json["Pct"] = new JSONBool(Pct);
        }
        {
            _json["FinalAdd"] = new JSONBool(FinalAdd);
        }
        {
            _json["FinalPct"] = new JSONBool(FinalPct);
        }
    }

    public static NumericInfo LoadJsonNumericInfo(SimpleJSON.JSONNode _json)
    {
        NumericInfo obj = new NumericInfo();
        obj.LoadJson((SimpleJSON.JSONObject)_json);
        return obj;
    }
        
    public static void SaveJsonNumericInfo(NumericInfo _obj, SimpleJSON.JSONNode _json)
    {
        _obj.SaveJson((SimpleJSON.JSONObject)_json);
    }

    public string Name;

    public bool Base;

    public bool Add;

    public bool Pct;

    public bool FinalAdd;

    public bool FinalPct;

}
}
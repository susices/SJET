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
public sealed partial class PlayerNumericConfig :  Bright.Config.EditorBeanBase 
{
    public PlayerNumericConfig()
    {
            Name = "";
    }

    public override void LoadJson(SimpleJSON.JSONObject _json)
    {
        { 
            var _fieldJson = _json["Id"];
            if (_fieldJson != null)
            {
                if(!_fieldJson.IsNumber) { throw new SerializationException(); }  Id = _fieldJson;
            }
        }
        
        { 
            var _fieldJson = _json["Name"];
            if (_fieldJson != null)
            {
                if(!_fieldJson.IsString) { throw new SerializationException(); }  Name = _fieldJson;
            }
        }
        
        { 
            var _fieldJson = _json["BaseValue"];
            if (_fieldJson != null)
            {
                if(!_fieldJson.IsNumber) { throw new SerializationException(); }  BaseValue = _fieldJson;
            }
        }
        
        { 
            var _fieldJson = _json["IsNeedShow"];
            if (_fieldJson != null)
            {
                if(!_fieldJson.IsNumber) { throw new SerializationException(); }  IsNeedShow = _fieldJson;
            }
        }
        
        { 
            var _fieldJson = _json["IsAddPoint"];
            if (_fieldJson != null)
            {
                if(!_fieldJson.IsNumber) { throw new SerializationException(); }  IsAddPoint = _fieldJson;
            }
        }
        
    }

    public override void SaveJson(SimpleJSON.JSONObject _json)
    {
        {
            _json["Id"] = new JSONNumber(Id);
        }
        {

            if (Name == null) { throw new System.ArgumentNullException(); }
            _json["Name"] = new JSONString(Name);
        }
        {
            _json["BaseValue"] = new JSONNumber(BaseValue);
        }
        {
            _json["IsNeedShow"] = new JSONNumber(IsNeedShow);
        }
        {
            _json["IsAddPoint"] = new JSONNumber(IsAddPoint);
        }
    }

    public static PlayerNumericConfig LoadJsonPlayerNumericConfig(SimpleJSON.JSONNode _json)
    {
        PlayerNumericConfig obj = new PlayerNumericConfig();
        obj.LoadJson((SimpleJSON.JSONObject)_json);
        return obj;
    }
        
    public static void SaveJsonPlayerNumericConfig(PlayerNumericConfig _obj, SimpleJSON.JSONNode _json)
    {
        _obj.SaveJson((SimpleJSON.JSONObject)_json);
    }

    /// <summary>
    /// Id
    /// </summary>
    public int Id;

    /// <summary>
    /// 名字
    /// </summary>
    public string Name;

    /// <summary>
    /// 初始基础值
    /// </summary>
    public long BaseValue;

    /// <summary>
    /// 是否用于展示
    /// </summary>
    public int IsNeedShow;

    /// <summary>
    /// 是否用于加成点
    /// </summary>
    public int IsAddPoint;

}
}

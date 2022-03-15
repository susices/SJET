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



namespace ET.ConfigEditor
{

public sealed partial class StartSceneConfig :  Bright.Config.EditorBeanBase 
{
    public StartSceneConfig()
    {
            SceneType = "";
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
            var _fieldJson = _json["Process"];
            if (_fieldJson != null)
            {
                if(!_fieldJson.IsNumber) { throw new SerializationException(); }  Process = _fieldJson;
            }
        }
        
        { 
            var _fieldJson = _json["Zone"];
            if (_fieldJson != null)
            {
                if(!_fieldJson.IsNumber) { throw new SerializationException(); }  Zone = _fieldJson;
            }
        }
        
        { 
            var _fieldJson = _json["SceneType"];
            if (_fieldJson != null)
            {
                if(!_fieldJson.IsString) { throw new SerializationException(); }  SceneType = _fieldJson;
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
            var _fieldJson = _json["OuterPort"];
            if (_fieldJson != null)
            {
                if(!_fieldJson.IsNumber) { throw new SerializationException(); }  OuterPort = _fieldJson;
            }
        }
        
    }

    public override void SaveJson(SimpleJSON.JSONObject _json)
    {
        {
            _json["Id"] = new JSONNumber(Id);
        }
        {
            _json["Process"] = new JSONNumber(Process);
        }
        {
            _json["Zone"] = new JSONNumber(Zone);
        }
        {

            if (SceneType == null) { throw new System.ArgumentNullException(); }
            _json["SceneType"] = new JSONString(SceneType);
        }
        {

            if (Name == null) { throw new System.ArgumentNullException(); }
            _json["Name"] = new JSONString(Name);
        }
        {
            _json["OuterPort"] = new JSONNumber(OuterPort);
        }
    }

    public static StartSceneConfig LoadJsonStartSceneConfig(SimpleJSON.JSONNode _json)
    {
        StartSceneConfig obj = new StartSceneConfig();
        obj.LoadJson((SimpleJSON.JSONObject)_json);
        return obj;
    }
        
    public static void SaveJsonStartSceneConfig(StartSceneConfig _obj, SimpleJSON.JSONNode _json)
    {
        _obj.SaveJson((SimpleJSON.JSONObject)_json);
    }

    /// <summary>
    /// Id
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// 所属进程
    /// </summary>
    public int Process { get; set; }

    /// <summary>
    /// 所属区
    /// </summary>
    public int Zone { get; set; }

    /// <summary>
    /// 类型
    /// </summary>
    public string SceneType { get; set; }

    /// <summary>
    /// 名字
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// 外网端口
    /// </summary>
    public int OuterPort { get; set; }

}
}

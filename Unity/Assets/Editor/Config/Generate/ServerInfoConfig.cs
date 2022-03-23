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

public sealed partial class ServerInfoConfig :  Bright.Config.EditorBeanBase 
{
    public ServerInfoConfig()
    {
            ServerName = "";
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
            var _fieldJson = _json["ServerName"];
            if (_fieldJson != null)
            {
                if(!_fieldJson.IsString) { throw new SerializationException(); }  ServerName = _fieldJson;
            }
        }
        
    }

    public override void SaveJson(SimpleJSON.JSONObject _json)
    {
        {
            _json["Id"] = new JSONNumber(Id);
        }
        {

            if (ServerName == null) { throw new System.ArgumentNullException(); }
            _json["ServerName"] = new JSONString(ServerName);
        }
    }

    public static ServerInfoConfig LoadJsonServerInfoConfig(SimpleJSON.JSONNode _json)
    {
        ServerInfoConfig obj = new ServerInfoConfig();
        obj.LoadJson((SimpleJSON.JSONObject)_json);
        return obj;
    }
        
    public static void SaveJsonServerInfoConfig(ServerInfoConfig _obj, SimpleJSON.JSONNode _json)
    {
        _obj.SaveJson((SimpleJSON.JSONObject)_json);
    }

    /// <summary>
    /// Id
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// 所属ai
    /// </summary>
    public string ServerName { get; set; }

}
}
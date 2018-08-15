using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime;
using System;
using LitJson;

[Serializable]
public class ConfigClass
{
    public int id;
    public void LogData() {
        Debug.Log(JsonMapper.ToJson(this));
    }
}

[Serializable]
public class Global : ConfigClass
{
    public string version;
    public bool isDebug;
    public float bgRoteSpeed;
}

[Serializable]
public class DeserializeClass
{
    public ConfigClass[] cfgArray;
}

[Serializable]
public class DeserializeGlobal : DeserializeClass
{
    public new Global[] cfgArray;
}
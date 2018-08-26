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
    public double bgRoteSpeed;
}

[Serializable]
public class RandomEvent : ConfigClass
{
    public string name;
    public string desc;
    public string spriteName;
    public int opA;
    public int opB;
    public int opC;
    public int opD;
}

[Serializable]
public class Option : ConfigClass
{
    public string desc;
    public string result;
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

[Serializable]
public class DeserializeRandomEvent : DeserializeClass
{
    public new RandomEvent[] cfgArray;
}

[Serializable]
public class DeserializeOption : DeserializeClass
{
    public new Option[] cfgArray;
}
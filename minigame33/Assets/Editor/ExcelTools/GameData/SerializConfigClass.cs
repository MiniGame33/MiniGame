using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime;
using System;
using LitJson;
[Serializable]
public class SerializConfigClass
{
    public int id;
}

[Serializable]
public class SerializGlobal : SerializConfigClass
{
    public string version;
    public bool isDebug;
    public double bgRoteSpeed;
}

[Serializable]
public class SerializRandomEvent : SerializConfigClass
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
public class SerializOption : SerializConfigClass
{
    public string desc;
    public string result;
}

[Serializable]
public class SerializDailyEvent : SerializConfigClass
{
    public string name;
    public string desc;
    public string spriteName;
}

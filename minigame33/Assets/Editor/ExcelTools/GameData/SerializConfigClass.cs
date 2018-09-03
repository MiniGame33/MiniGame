﻿using UnityEngine;
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
    public int initPopu;
    public int initFood;
    public int initArm;
    public int initTech;
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

[Serializable]
public class SerializProcess : SerializConfigClass
{
    public int dayRandom;
    public int dayDaily1;
    public int dayDaily2;
    public int dayDaily3;
    public int nightRandom;
    public int nightDaily1;
    public int nightDaily2;
}

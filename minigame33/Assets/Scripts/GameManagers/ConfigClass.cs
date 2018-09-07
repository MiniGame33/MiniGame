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
    public double initPopu;
    public double initFood;
    public double initArm;
    public double initTech;
    public double initBeli;
    public double caiji_food;
    public double dazao_arm;
    public double dazao_food;
    public double shoulie_food;
    public double shoulie_popu;
    public double jisi_beli;
    public double jisi_food;
    public double random_arm;
    public double random_food;
    public double random_popu;
    public double random_beli;
    public double random_tech;
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
    public double popu;
    public double food;
    public double arm;
    public double tech;
    public double beli;
    public string buff1;
    public double buff_num1;
    public string buff2;
    public double buff_num2;
}

[Serializable]
public class DailyEvent : ConfigClass
{
    public string name;
    public string desc;
    public string spriteName;
    public string eventNotify;
}

[Serializable]
public class Process : ConfigClass
{
    public int dayRandom;
    public int dayDaily1;
    public int dayDaily2;
    public int dayDaily3;
    public int nightRandom;
    public int nightDaily1;
    public int nightDaily2;
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

[Serializable]
public class DeserializeDailyEvent : DeserializeClass
{
    public new DailyEvent[] cfgArray;
}

[Serializable]
public class DeserializeProcess : DeserializeClass
{
    public new Process[] cfgArray;
}
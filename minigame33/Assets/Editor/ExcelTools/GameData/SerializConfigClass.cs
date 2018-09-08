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
    public int initPopu;
    public int initFood;
    public int initArm;
    public int initTech;
    public int initBeli;
    public double caiji_food;
    public double dazao_arm;
    public double dazao_food;
    public double shoulie_arm;
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
public class SerializRandomEvent : SerializConfigClass
{
    public string name;
    public string desc;
    public string spriteName;
    public int opA;
    public int opB;
    public int opC;
}

[Serializable]
public class SerializOption : SerializConfigClass
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
    public string unlock;
    public double unlock_num;
}

[Serializable]
public class SerializDailyEvent : SerializConfigClass
{
    public string name;
    public string desc;
    public string spriteName;
    public string eventNotify;
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

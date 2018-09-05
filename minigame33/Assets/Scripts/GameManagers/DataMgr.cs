﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataMgr : MonoBehaviour {
    public static DataMgr _instance;
    public Global global;

    public float popu;
    public float food;
    public float arm;
    public float tech;
    public float beli;

    public float caiji_food;
    public float dazao_arm;
    public float dazao_food;
    public float shoulie_food;
    public float shoulie_popu;
    public float jisi_beli;
    public float jisi_food;

    public float random_arm;
    public float random_food;
    public float random_popu;
    public float random_beli;
    public float random_tech;
    // Use this for initialization
    private void Awake()
    {
        _instance = this;
    }
    private void OnEnable()
    {
        NotifacitionCenter.getInstance().On("OnGather",OnGather);
        NotifacitionCenter.getInstance().On("OnHunt", OnHunt);
        NotifacitionCenter.getInstance().On("OnForge", OnForge);
        NotifacitionCenter.getInstance().On("OnSacrifice", OnSacrifice);
    }
    private void OnDisable()
    {
        NotifacitionCenter.getInstance().Off("OnGather", OnGather);
        NotifacitionCenter.getInstance().Off("OnHunt", OnHunt);
        NotifacitionCenter.getInstance().Off("OnForge", OnForge);
        NotifacitionCenter.getInstance().Off("OnSacrifice", OnSacrifice);
    }
    void Start () {
        if (CfgTabelData.GetInstance().GetCfgTabelByName("Global") != null)
        {
            global = CfgTabelData.GetInstance().GetCfgTabelByName("Global").getDataByID(1) as Global;
            popu = (float)global.initPopu;
            food = (float)global.initFood;
            arm = (float)global.initArm;
            tech = (float)global.initTech;
            beli = (float)global.initBeli;

            caiji_food = (float)global.caiji_food;
            dazao_arm = (float)global.dazao_arm;
            dazao_food = (float)global.dazao_food;
            shoulie_food = (float)global.shoulie_food;
            shoulie_popu = (float)global.shoulie_popu;
            jisi_beli = (float)global.jisi_beli;
            jisi_food = (float)global.jisi_food;

            random_arm = (float)global.random_arm;
            random_food = (float)global.random_food;
            random_popu = (float)global.random_popu;
            random_beli = (float)global.random_beli;
            random_tech = (float)global.random_tech;
        }
        UIMgr._instance.mainUI.SetAttr();
    }

    public void DailyRun()
    {
        float _popu = popu;
        float _food = food;
        popu += _popu * random_popu;
        food += _popu * random_food;
        UIMgr._instance.mainUI.SetAttr();
    }

    public void OnGather(NotifyEvent _event = null)
    {
        float _popu = popu;
        float _food = food;
        food += _popu * caiji_food;
        UIMgr._instance.mainUI.SetAttr();
    }
    public void OnHunt(NotifyEvent _event = null)
    {
        float _food = food;
        float _popu = popu;
        food += _popu * shoulie_food;
        popu += _popu * shoulie_popu;
        UIMgr._instance.mainUI.SetAttr();
    }
    public void OnForge(NotifyEvent _event = null)
    {
        float _arm = arm;
        float _food = food;
        float _popu = popu;
        arm += _popu * dazao_arm;
        food += _food * dazao_food;
        UIMgr._instance.mainUI.SetAttr();
    }
    public void OnSacrifice(NotifyEvent _event = null)
    {
        float _food = food;
        float _popu = popu;
        float _beli = beli;
        beli += _popu * jisi_beli;
        food += _food * jisi_food;
        UIMgr._instance.mainUI.SetAttr();
    }

    public void OnRandomEvent(Option op) {
        float _food = food;
        float _popu = popu;
        float _beli = beli;
        float _arm = arm;
        float _tech = tech;
        food += _popu * random_food * (float)op.food;
        popu += _popu * random_popu * (float)op.popu;
        beli += _popu * random_beli * (float)op.beli;
        arm += _popu * random_arm * (float)op.arm;
        tech += _popu * random_tech * (float)op.tech;
        UIMgr._instance.mainUI.SetAttr();
    }
}

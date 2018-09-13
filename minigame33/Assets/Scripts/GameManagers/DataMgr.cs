using System.Collections;
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
    public float shoulie_arm;
    public float shoulie_food;
    public float shoulie_popu;
    public float jisi_beli;
    public float jisi_food;

    public float random_arm;
    public float random_food;
    public float random_beli;
    public float random_tech;

    public float random_popu_c;
    public float random_popu_k;
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
            shoulie_arm = (float)global.shoulie_arm;
            shoulie_food = (float)global.shoulie_food;
            shoulie_popu = (float)global.shoulie_popu;
            jisi_beli = (float)global.jisi_beli;
            jisi_food = (float)global.jisi_food;

            random_arm = (float)global.random_arm;
            random_food = (float)global.random_food;
            random_beli = (float)global.random_beli;
            random_tech = (float)global.random_tech;

            random_popu_c = (float)global.random_popu_c;
            random_popu_k = (float)global.random_popu_k;
        }
        UIMgr._instance.mainUI.SetAttr();
    }

    public void DailyRun()
    {
        float _popu = popu;
        float _food = food;
        //popu += _popu * random_popu;
        food += _popu * random_food;
        if (food < 0)
        {
            popu += -food * random_popu_k + random_popu_c;
            food = 0;
        }
        UIMgr._instance.mainUI.SetAttr();
    }

    public void OnGather(NotifyEvent _event = null)
    {
        string reslutString = "获得食物";
        float _popu = popu;
        float _food = food;
        food += _popu * caiji_food;
        reslutString += (_popu * caiji_food).ToString()+" ";
        UIMgr._instance.mainUI.SetAttr();
        DailyEvent dailyEventCfg = _event.Details as DailyEvent;
        UIMgr._instance.mainUI.ShowEventPanel(dailyEventCfg);
        NotifacitionCenter.getInstance().Emit("EventHide", this);
        EventUI._instance.resultString = reslutString;
    }
    public void OnHunt(NotifyEvent _event = null)
    {
        string reslutString = "损失武器";
        float _food = food;
        float _popu = popu;
        float _arm = arm;

        float add_arm = _popu * shoulie_arm;
        if (Mathf.Abs(add_arm) > _arm)
        {
            add_arm = -_arm;
        }
        arm += add_arm;
        reslutString += (-add_arm).ToString() + " ";
        reslutString += "损失人口";
        float add_popu = 0;
        add_popu = (_arm + add_arm) * 10 * shoulie_popu + _popu * shoulie_popu;
        popu += add_popu;
        reslutString += (-add_popu).ToString() + " ";
        reslutString += "获得食物";
        float add_food = 0;
        add_food = -add_popu * shoulie_food - add_arm * 2 * shoulie_food; 
        food += add_food;
        reslutString += add_food.ToString() + " ";
        UIMgr._instance.mainUI.SetAttr();
        DailyEvent dailyEventCfg = _event.Details as DailyEvent;
        UIMgr._instance.mainUI.ShowEventPanel(dailyEventCfg);
        NotifacitionCenter.getInstance().Emit("EventHide", this);
        AudioMgr._instance.Play(AudioMgr._instance.huntBgm, false);
        EventUI._instance.resultString = reslutString;
    }
    public void OnForge(NotifyEvent _event = null)
    {
        string reslutString = "获得武器";
        float _arm = arm;
        float _food = food;
        float _popu = popu;
        if (_food + _food * dazao_food < 0)
        {
            return;
        }
        arm += _popu * dazao_arm;
        reslutString += (_popu * dazao_arm).ToString() + " ";
        reslutString += "损失食物";
        food += _food * dazao_food;
        reslutString += (-_food * dazao_food).ToString() + " ";
        UIMgr._instance.mainUI.SetAttr();
        DailyEvent dailyEventCfg = _event.Details as DailyEvent;
        UIMgr._instance.mainUI.ShowEventPanel(dailyEventCfg);
        NotifacitionCenter.getInstance().Emit("EventHide", this);
        EventUI._instance.resultString = reslutString;
    }
    public void OnSacrifice(NotifyEvent _event = null)
    {
        string reslutString = "获得信仰";
        float _food = food;
        float _popu = popu;
        float _beli = beli;
        if (_food + jisi_food < 0)
        {
            return;
        }
        beli += jisi_beli;
        reslutString += jisi_beli.ToString() + " ";
        reslutString += "损失食物";
        food += jisi_food;
        reslutString += (-jisi_food).ToString() + " ";
        UIMgr._instance.mainUI.SetAttr();
        DailyEvent dailyEventCfg = _event.Details as DailyEvent;
        UIMgr._instance.mainUI.ShowEventPanel(dailyEventCfg);
        NotifacitionCenter.getInstance().Emit("EventHide", this);
        EventUI._instance.resultString = reslutString;
    }

    public void OnRandomEvent(Option op) {
        float _food = food;
        float _popu = popu;
        float _beli = beli;
        float _arm = arm;
        float _tech = tech;
        food += _popu * random_food * (float)op.food;
        popu += (float)op.popu;
        beli += _popu * random_beli * (float)op.beli;
        arm += _popu * random_arm * (float)op.arm;
        tech += _popu * random_tech * (float)op.tech;
        SetBuff(op.buff1, (float)op.buff_num1);
        SetBuff(op.buff2, (float)op.buff_num2);
        UIMgr._instance.mainUI.SetAttr();
    }
    public void SetBuff(string buffName,float buffNum) {
        switch (buffName)
        {
            case "random_arm":
                random_arm = buffNum;
                break;
            case "random_food":
                random_food = buffNum;
                break;
            case "random_beli":
                random_beli = buffNum;
                break;
            case "random_tech":
                random_tech = buffNum;
                break;
            case "random_popu_c":
                random_popu_c = buffNum;
                break;
            case "random_popu_k":
                random_popu_k = buffNum;
                break;
            default:
                break;
        }
    }
    public bool CheckUnlock(string unlock,float unlock_num) {
        switch (unlock)
        {
            case "popu":
                if (popu < unlock_num)
                    return false;
                break;
            case "food":
                if (food < unlock_num)
                    return false;
                break;
            case "arm":
                if (arm < unlock_num)
                    return false;
                break;
            case "tech":
                if (tech < unlock_num)
                    return false;
                break;
            case "beli":
                if (beli < unlock_num)
                    return false;
                break;
            default:
                break;
        }
        return true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataMgr : MonoBehaviour {
    public static DataMgr _instance;
    public Global global;

    public int popu;
    public int food;
    public int arm;
    public int tech;
    // Use this for initialization
    private void Awake()
    {
        _instance = this;
    }
    void Start () {
        if (CfgTabelData.GetInstance().GetCfgTabelByName("Global") != null)
        {
            global = CfgTabelData.GetInstance().GetCfgTabelByName("Global").getDataByID(1) as Global;
            popu = global.initPopu;
            food = global.initFood;
            arm = global.initArm;
            tech = global.initTech;
        }
        UIMgr._instance.mainUI.SetAttr();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

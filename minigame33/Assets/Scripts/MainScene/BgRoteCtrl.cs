using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgRoteCtrl : MonoBehaviour {
    public double roteSpeed = 0;
    private void Awake()
    {
        if (roteSpeed == 0)
        {
            Global _global = CfgTabelData.GetInstance().GetCfgTabelByName("Global").getDataByID(1) as Global;
            roteSpeed = _global.bgRoteSpeed;
        }
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.Rotate(new Vector3(0, 0, (float)roteSpeed * Time.deltaTime));
	}
}

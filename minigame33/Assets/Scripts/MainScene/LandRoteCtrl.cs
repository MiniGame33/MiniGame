using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandRoteCtrl : MonoBehaviour {

    public double roteSpeed = 0;
    private void Awake()
    {
        if (CfgTabelData.GetInstance().GetCfgTabelByName("Global")!=null)
        {
            Global _global = CfgTabelData.GetInstance().GetCfgTabelByName("Global").getDataByID(1) as Global;
            roteSpeed = _global.bgRoteSpeed;
        }
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerMgr._instance.needRote)
        {
            this.transform.Rotate(new Vector3(0, 0, (float)roteSpeed * Time.deltaTime));
        }
    }
}

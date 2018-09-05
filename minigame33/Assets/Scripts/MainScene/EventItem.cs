using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class EventItem : MonoBehaviour {
    public Vector3 startPos;
    public Vector3 endPos;
    public int id;

    public DailyEvent dailyEventCfg;
	// Use this for initialization
	private void Awake()
	{
	}
	void Start () {
        startPos = transform.localPosition;
        endPos = startPos + new Vector3(0, 0.125f, 0);
        transform.DOLocalMove(endPos, 0.5f).SetLoops(-1,LoopType.Yoyo);
        dailyEventCfg = CfgTabelData.GetInstance().GetCfgTabelByName("DailyEvent").getDataByID(id) as DailyEvent;
	}
	
	// Update is called once per frame
	void Update () {
        
	}

	private void OnMouseDown()
    {
        NotifacitionCenter.getInstance().Emit("EventHide", this);
        UIMgr._instance.mainUI.ShowEventPanel(dailyEventCfg);
        NotifacitionCenter.getInstance().Emit(dailyEventCfg.eventNotify,this);
    }
}

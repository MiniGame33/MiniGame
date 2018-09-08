using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventMgr : MonoBehaviour {
    public static EventMgr _instance;
    public List<EventItem> eventItems;
    public GameObject _camera;
    public Transform randomPos;
    public GameObject randomEvent;
    public GameObject player;

    public Vector3 mainCameraPos;
    public Vector3 eventCameraPos;
    public bool checkRandomEvent = false;

    public CfgTabelData.CfgDataList randomEventCfg;
    public CfgTabelData.CfgDataList optionCfg;

    public int randomEventId = 0;
    public List<int> randomList = new List<int> { 0,0,0,0,0,0,0};
    private void OnEnable()
	{
        NotifacitionCenter.getInstance().On("EventHide",Hide);
        NotifacitionCenter.getInstance().On("EndRandomEvent", EndRandomEvent);
    }
	private void OnDisable()
	{
        NotifacitionCenter.getInstance().Off("EventHide", Hide);
        NotifacitionCenter.getInstance().Off("EndRandomEvent", EndRandomEvent);
    }
	private void Awake()
	{
        _instance = this;
        randomEventCfg = CfgTabelData.GetInstance().GetCfgTabelByName("RandomEvent");
        optionCfg = CfgTabelData.GetInstance().GetCfgTabelByName("Option");
    }
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        randomList[2] = 1;
        Hide();
	}
	
	// Update is called once per frame
	void Update () {
        if (checkRandomEvent&&
            Vector3.Distance(randomEvent.transform.position, player.transform.position) < 1) {
            StartRandomEvent(randomEventId);
        }
    }

    public void Hide(NotifyEvent _event = null)
    {
        for (int i = 0; i < eventItems.Count; i++)
        {
            eventItems[i].gameObject.SetActive(false);
        }
    }

    public void DayDailyShow(NotifyEvent _event = null)
    {
        Process process = PlayerMgr._instance._processCfg.getDataByID(PlayerMgr._instance.day) as Process;
        for (int i = 0; i < eventItems.Count; i++)
        {
            if (eventItems[i].id == process.dayDaily1
                || eventItems[i].id == process.dayDaily2
                || eventItems[i].id == process.dayDaily3)
            eventItems[i].gameObject.SetActive(true);
        }
    }
    public void NightDailyShow(NotifyEvent _event = null)
    {
        Process process = PlayerMgr._instance._processCfg.getDataByID(PlayerMgr._instance.day) as Process;
        for (int i = 0; i < eventItems.Count; i++)
        {
            if (eventItems[i].id == process.nightDaily1
                || eventItems[i].id == process.nightDaily2)
                eventItems[i].gameObject.SetActive(true);
        }
    }
    public void SetDayRandomEvent() {
        Process process = PlayerMgr._instance._processCfg.getDataByID(PlayerMgr._instance.day) as Process;
        if (randomEventCfg.getDataByID(process.dayRandom) == null) {
            PlayerMgr._instance.EndRandomEvent();
            return;
        }
        checkRandomEvent = true;
        randomEventId = process.dayRandom;
        randomEvent.SetActive(true);
        randomEvent.transform.position = randomPos.position;
        randomEvent.transform.rotation = randomPos.rotation;
    }

    public void SetNightRandomEvent()
    {
        Process process = PlayerMgr._instance._processCfg.getDataByID(PlayerMgr._instance.day) as Process;
        if (randomEventCfg.getDataByID(process.nightRandom) == null)
        {
            PlayerMgr._instance.EndRandomEvent();
            return;
        }
        randomEventId = process.nightRandom;
        StartRandomEvent(randomEventId);
    }

    public void StartRandomEvent(int _id) {
        checkRandomEvent = false;
        UIMgr._instance.mainUI.randomEventPanel.Show(randomEventCfg.getDataByID(_id) as RandomEvent);
        PlayerMgr._instance.needRote = false;
    }

    public void EndRandomEvent(NotifyEvent _event = null) {
        randomEvent.SetActive(false);
    }
}

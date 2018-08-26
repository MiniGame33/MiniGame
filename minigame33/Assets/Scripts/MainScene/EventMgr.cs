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
    private void OnEnable()
	{
        NotifacitionCenter.getInstance().On("EventHide",Hide);
        NotifacitionCenter.getInstance().On("EventShow", Show);
        NotifacitionCenter.getInstance().On("EndRandomEvent", EndRandomEvent);
    }
	private void OnDisable()
	{
        NotifacitionCenter.getInstance().Off("EventHide", Hide);
        NotifacitionCenter.getInstance().Off("EventShow", Show);
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
        Hide();
	}
	
	// Update is called once per frame
	void Update () {
        if (checkRandomEvent&&
            Vector3.Distance(randomEvent.transform.position, player.transform.position) < 1) {
            StartRandomEvent();
        }
    }

    public void Hide(NotifyEvent _event = null)
    {
        for (int i = 0; i < eventItems.Count; i++)
        {
            eventItems[i].gameObject.SetActive(false);
        }
    }

    public void Show(NotifyEvent _event = null)
    {
        for (int i = 0; i < eventItems.Count; i++)
        {
            eventItems[i].gameObject.SetActive(true);
        }
    }

    public void SetRandomEvent() {
        checkRandomEvent = true;
        randomEvent.SetActive(true);
        randomEvent.transform.position = randomPos.position;
        randomEvent.transform.rotation = randomPos.rotation;
    }

    public void StartRandomEvent(NotifyEvent _event = null) {
        checkRandomEvent = false;
        UIMgr._instance.randomEventUI.Show(randomEventCfg.getDataByID(1) as RandomEvent);
        PlayerMgr._instance.needRote = false;
    }

    public void EndRandomEvent(NotifyEvent _event = null) {
        randomEvent.SetActive(false);
    }
}

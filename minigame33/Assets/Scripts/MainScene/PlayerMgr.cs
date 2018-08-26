using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class PlayerMgr : MonoBehaviour {
    public static PlayerMgr _instance;

    public SpriteRenderer mainBgDay;
    public SpriteRenderer mainBgNight;
    public Animator ani;

    public bool needRote = false;
    public float showEventLabelTime;
    public float showEventTime;
    public Vector3 bgStartPos;
    public Vector3 bgEndPos;

    private float _showEventLabelTime = -10000;
    private float _showEventTime = -10000;

    public int day;

    private void OnEnable()
    {
        NotifacitionCenter.getInstance().On("OnEnterDay", EnterDay);
        NotifacitionCenter.getInstance().On("OnEnterNight", EnterNight);
        NotifacitionCenter.getInstance().On("EndRandomEvent", EndRandomEvent);
    }
    private void OnDisable()
    {
        NotifacitionCenter.getInstance().Off("OnEnterDay", EnterDay);
        NotifacitionCenter.getInstance().Off("OnEnterNight", EnterNight);
        NotifacitionCenter.getInstance().Off("EndRandomEvent", EndRandomEvent);
    }
    private void Awake()
	{
        _instance = this;
        day = 0;
	}
	// Use this for initialization
	void Start () {
        EnterDay();
    }
	
	// Update is called once per frame
	void Update () {
        if (_showEventLabelTime < showEventLabelTime)
        {
            _showEventLabelTime += Time.deltaTime;
        }
        else
        {
            UIMgr._instance.mainUI.eventLabel.gameObject.SetActive(true);
            _showEventLabelTime = -10000;
        }
        if(_showEventTime < showEventTime){
            _showEventTime += Time.deltaTime;
        }
        else
        {
            this.needRote = false;
            NotifacitionCenter.getInstance().Emit("EventShow",this);
            _showEventTime = -10000;
        }
        ani.SetBool("walk", this.needRote);
    }

    public void EnterDay(NotifyEvent _event = null){
        day++;
        needRote = true;
        _showEventLabelTime = -10000;
        _showEventTime = -10000;
        EventMgr._instance.SetRandomEvent();
        mainBgNight.transform.DOLocalMove(new Vector3(0,35,0),2f);
    }
    public void EnterNight(NotifyEvent _event = null)
    {
        mainBgNight.transform.DOLocalMove(new Vector3(0, 5, 0), 2f);
    }

    public void EndRandomEvent(NotifyEvent _event = null) {
        needRote = true;
        _showEventLabelTime = 0;
        _showEventTime = 0;
    }
}

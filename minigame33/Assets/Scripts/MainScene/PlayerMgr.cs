using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class PlayerMgr : MonoBehaviour {
    public static PlayerMgr _instance;

    public SpriteRenderer mainBgDay;
    public SpriteRenderer mainBgNight;

    public bool needRote = true;
    public float showEventLabelTime;
    public float showEventTime;
    public Vector3 bgStartPos;
    public Vector3 bgEndPos;

    private float _showEventLabelTime = 0;
    private float _showEventTime = 0;

    public int day;

    private void OnEnable()
    {
        NotifacitionCenter.getInstance().On("OnEnterDay", EnterDay);
        NotifacitionCenter.getInstance().On("OnEnterNight", EnterNight);
    }
    private void OnDisable()
    {
        NotifacitionCenter.getInstance().Off("OnEnterDay", EnterDay);
        NotifacitionCenter.getInstance().Off("OnEnterNight", EnterNight);
    }
    private void Awake()
	{
        _instance = this;
        day = 1;
	}
	// Use this for initialization
	void Start () {
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
	}

    public void EnterDay(NotifyEvent _event){
        day++;
        needRote = true;
        _showEventLabelTime = 0;
        _showEventTime = 0;
        mainBgNight.transform.DOLocalMove(new Vector3(0,35,0),2f);
    }
    public void EnterNight(NotifyEvent _event)
    {
        mainBgNight.transform.DOLocalMove(new Vector3(0, 5, 0), 2f);
    }
}

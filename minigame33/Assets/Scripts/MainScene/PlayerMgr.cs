using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMgr : MonoBehaviour {
    public static PlayerMgr _instance;

    public SpriteRenderer mainBg;

    public float showEventLabelTime;
    public float showEventTime;

    private float _showEventLabelTime = 0;
    private float _showEventTime = 0;

    public int day;
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
            MainUI._instance.eventLabel.gameObject.SetActive(true);
            _showEventLabelTime = -10000;
        }
        if(_showEventTime < showEventTime){
            _showEventTime += Time.deltaTime;
        }
        else
        {
            NotifacitionCenter.getInstance().Emit("EventShow",this);
            _showEventTime = -10000;
        }
	}

    public void EnterDay(){
        
    }
    public void EnterNight(){
        
    }
}

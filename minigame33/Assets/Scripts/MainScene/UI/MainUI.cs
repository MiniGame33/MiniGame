using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MainUI : MonoBehaviour {

    public GameObject eventLabel;
    public EventUI eventPanel;
    public GameObject dayPanel;
    public GameObject nightPanel;
    public Slider dayBar;
	private void Awake()
	{
        eventLabel.SetActive(false);
        eventPanel.gameObject.SetActive(false);
        OnEnterDay();
    }
	private void OnEnable()
	{
		
	}
	private void OnDisable()
	{
		
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        dayBar.value = PlayerMgr._instance.day / 7.0f;
    }
    void ShowEventLabel(){
        
    }

    public void ShowEventPanel() {
        eventLabel.SetActive(false);
        eventPanel.gameObject.SetActive(true);
    }

    public void CloseEventPanel() {
        eventPanel.gameObject.SetActive(false);
        NotifacitionCenter.getInstance().Emit("OnEnterNight", this);
        OnEnterNight();
    }

    public void NextDay()
    {
        NotifacitionCenter.getInstance().Emit("OnEnterDay", this);
        OnEnterDay();
    }

    public void OnEnterNight() {
        dayPanel.SetActive(false);
        nightPanel.SetActive(true);
    }
    public void OnEnterDay()
    {
        dayPanel.SetActive(true);
        nightPanel.SetActive(false);
    }
}

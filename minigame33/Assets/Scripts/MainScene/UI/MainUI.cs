using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MainUI : MonoBehaviour {

    public GameObject eventLabel;
    public EventUI eventPanel;
    public UIDay dayPanel;
    public UINight nightPanel;
    public UIRandomEvent randomEventPanel;
    public Slider dayBar;
    public Text popu;
    public Text food;
    public Text arm;
    public Text tech;
    private void Awake()
	{
        eventLabel.SetActive(false);
        if (!dayPanel)
        {
            Object go = Resources.Load("Prefebs/UI/UIDayPanel");
            dayPanel = (Instantiate(go,Vector3.zero,Quaternion.identity,transform) as GameObject).GetComponent<UIDay>();
            dayPanel.transform.localPosition = Vector3.zero;
            dayPanel.gameObject.SetActive(false);
        }
        if (!nightPanel)
        {
            Object go = Resources.Load("Prefebs/UI/UINightPanel");
            nightPanel = (Instantiate(go, Vector3.zero, Quaternion.identity, transform) as GameObject).GetComponent<UINight>();
            nightPanel.transform.localPosition = Vector3.zero;
            nightPanel.gameObject.SetActive(false);
        }
        if (!eventPanel)
        {
            Object go = Resources.Load("Prefebs/UI/UIEventPanel");
            eventPanel = (Instantiate(go, Vector3.zero, Quaternion.identity, transform) as GameObject).GetComponent<EventUI>();
            eventPanel.transform.localPosition = Vector3.zero;
            eventPanel.gameObject.SetActive(false);
        }
        if (!randomEventPanel)
        {
            Object go = Resources.Load("Prefebs/UI/UIRandomEventPanel");
            randomEventPanel = (Instantiate(go, Vector3.zero, Quaternion.identity, transform) as GameObject).GetComponent<UIRandomEvent>();
            randomEventPanel.transform.localPosition = Vector3.zero;
            randomEventPanel.gameObject.SetActive(false);
        }
    }
	private void OnEnable()
	{
        NotifacitionCenter.getInstance().On("OnEnterDay",OnEnterDay);
        NotifacitionCenter.getInstance().On("OnEnterNight", OnEnterNight);
    }
	private void OnDisable()
	{
        NotifacitionCenter.getInstance().Off("OnEnterDay", OnEnterDay);
        NotifacitionCenter.getInstance().Off("OnEnterNight", OnEnterNight);
    }
	// Use this for initialization
	void Start () {
        OnEnterDay();
    }
	
	// Update is called once per frame
	void Update () {
        dayBar.value = PlayerMgr._instance.day / 7.0f;
    }

    public void SetAttr() {
        popu.text = DataMgr._instance.popu.ToString();
        food.text = DataMgr._instance.food.ToString();
        arm.text = DataMgr._instance.arm.ToString();
        tech.text = DataMgr._instance.tech.ToString();
    }

    public void ShowEventPanel(DailyEvent dailyEvent) {
        eventLabel.SetActive(false);
        eventPanel.Show(dailyEvent);
    }

    public void OnEnterNight(NotifyEvent _event = null) {
        dayPanel.gameObject.SetActive(false);
        nightPanel.gameObject.SetActive(true);
    }
    public void OnEnterDay(NotifyEvent _event = null)
    {
        dayPanel.gameObject.SetActive(true);
        nightPanel.gameObject.SetActive(false);
    }
}

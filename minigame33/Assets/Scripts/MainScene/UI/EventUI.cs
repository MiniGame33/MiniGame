using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EventUI : MonoBehaviour {
    public static EventUI _instance;
    public Text title;
    public Text desc;
    public Image imageBg;
    public GameObject resultGo;
    public Text result;
    public string resultString;
    private void Awake()
	{
        _instance = this;
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Show(DailyEvent dailyEvent){
        title.text = dailyEvent.name;
        desc.text = dailyEvent.desc;
        Object sp = Resources.Load(dailyEvent.spriteName, typeof(Sprite));
        imageBg.sprite = sp as Sprite;
        gameObject.SetActive(true);
        resultGo.SetActive(false);
    }
    public void ShowResult() {
        resultGo.SetActive(true);
        result.text = resultString;
    }
    public void Hide() {
        if (PlayerMgr._instance.isDay)
        {
            NotifacitionCenter.getInstance().Emit("OnEnterNight", this);
            AudioMgr._instance.Play(AudioMgr._instance.mainBgm, true);
        }
        else
        {
            UIMgr._instance.mainUI.ShowStory();
        }
        gameObject.SetActive(false);
    }
}

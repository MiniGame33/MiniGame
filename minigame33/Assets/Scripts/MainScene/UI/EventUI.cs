using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EventUI : MonoBehaviour {
    public static EventUI _instance;
    public Text title;
    public Text desc;
    public Image imageBg;
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
    }
    public void Hide() {
        if (PlayerMgr._instance.isDay)
        {
            NotifacitionCenter.getInstance().Emit("OnEnterNight", this);
        }
        else
        {
            UINight._instance.nextDayBtn.SetActive(true);
        }
        gameObject.SetActive(false);
    }
}

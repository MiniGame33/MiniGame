using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIRandomEvent : MonoBehaviour {
    public static UIRandomEvent _instance;

    public Text descText;
    public Text reslutText;
    public Text titleText;
    public Image imageBg;
    public GameObject close;
    public ScrollRect scrollRect;

    public bool over = false;
    public List<RandomEventOp> opList;
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

    public void Hide() {
        NotifacitionCenter.getInstance().Emit("EndRandomEvent",this);
        gameObject.SetActive(false);
    }
    public void Show(RandomEvent randomEvent)
    {
        reslutText.transform.parent.gameObject.SetActive(false);
        titleText.text = randomEvent.name;
        Object sp = Resources.Load(randomEvent.spriteName, typeof(Sprite));
        imageBg.sprite = sp as Sprite;
        descText.text = "\u3000\u3000" + randomEvent.desc;
        opList[0].Show(EventMgr._instance.optionCfg.getDataByID(randomEvent.opA) as Option);
        opList[1].Show(EventMgr._instance.optionCfg.getDataByID(randomEvent.opB) as Option);
        opList[2].Show(EventMgr._instance.optionCfg.getDataByID(randomEvent.opC) as Option);
        over = false;
        close.SetActive(false);
        gameObject.SetActive(true);
    }
}

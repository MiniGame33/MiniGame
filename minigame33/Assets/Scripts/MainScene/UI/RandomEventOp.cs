using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomEventOp : MonoBehaviour {

    public Text opDesc;
    public Option op;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Show(Option option) {
        op = option;
        gameObject.SetActive(false);
        if (op == null)
        {
            return;
        }
        if (!DataMgr._instance.CheckUnlock(op.unlock,(float)op.unlock_num))
        {
            return;
        }
        opDesc.text = option.desc;
        gameObject.SetActive(true);
    }

    public void OnClick() {
        if (UIRandomEvent._instance.over)
        {
            return;
        }
        DataMgr._instance.OnRandomEvent(op);
        ResultTextShow();
        UIRandomEvent._instance.over = true;
    }

    public void ResultTextShow()
    {
        UIRandomEvent._instance.reslutText.text = op.result;
        UIRandomEvent._instance.reslutText.transform.parent.gameObject.SetActive(true);
        UIRandomEvent._instance.close.SetActive(true);
    }
}

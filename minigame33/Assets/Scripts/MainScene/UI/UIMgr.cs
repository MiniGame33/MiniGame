using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMgr : MonoBehaviour {
    public static UIMgr _instance;
    public Stack<GameObject> uiList = new Stack<GameObject>();
    public MainUI mainUI;

	private void Awake()
	{
        _instance = this;
	}
	// Use this for initialization
	void Start () {
        PushUI(mainUI.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PushUI(GameObject ui){
        if(uiList!=null && uiList.Count > 0)
        {
           uiList.Peek().SetActive(false);
        }
        uiList.Push(ui);
        uiList.Peek().SetActive(true);
    }

    public void PopUI(){
        if (uiList != null && uiList.Count > 0)
        {
            uiList.Pop().SetActive(false);
        }
        if (uiList != null && uiList.Count > 0)
        {
            uiList.Peek().SetActive(true);
        }
    }
}

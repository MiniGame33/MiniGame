using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UINight : MonoBehaviour {
    public static UINight _instance;
    public GameObject nextDayBtn;
    private void Awake()
    {
        _instance = this;
    }
    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }
    public void NextDay(){
        NotifacitionCenter.getInstance().Emit("OnEnterDay",this);
    }
}

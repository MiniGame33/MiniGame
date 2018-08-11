using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;

public class TestMillionwang : Photon.PunBehaviour {

    // Use this for initialization
    void Start () {
        PhotonNetwork.ConnectUsingSettings("1.0");
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log(JsonMapper.ToJson(CfgTabelData.GetInstance().GetCfgTabelByName("ExcelATest1")));
        }
	}

    public void CreatRoom() {
        if (PhotonNetwork.room != null)
        {
            PhotonNetwork.CreateRoom("room1");
        }
        else
        {
            Debug.LogError("AlreadyJoinedRoom:" + PhotonNetwork.room.Name);
        }
        
    }

    public override void OnCreatedRoom() {
        Debug.Log("OnCreatedRoom");
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("OnJoinedRoom:" + PhotonNetwork.room.Name);
    }
    
    
}

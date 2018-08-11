﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMgr : MonoBehaviour {
    public static LoadMgr _instance;

    private void Awake()
    {
        _instance = this;
    }

    // Use this for initialization
    void Start () {

	}

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L)) 
        {
            SceneManager.LoadScene("Test");
        }
    }
}

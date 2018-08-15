using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMgr : MonoBehaviour {
    public static LoadMgr _instance;
    public int loadNum = 1;
    public GameObject Gm;
    private void Awake()
    {
        _instance = this;
        DontDestroyOnLoad(Gm);
    }

    private void Update()
    {
        if (loadNum <= 0)
        {
            SceneManager.LoadScene(1);
        }
    }
}

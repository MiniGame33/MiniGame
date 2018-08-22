using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainUI : MonoBehaviour {
    public static MainUI _instance;

    public GameObject eventLabel;
	private void Awake()
	{
        _instance = this;
	}
	private void OnEnable()
	{
		
	}
	private void OnDisable()
	{
		
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void ShowEventLabel(){
        
    }
}

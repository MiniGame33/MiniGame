using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoMgr : MonoBehaviour {
    public static VideoMgr _instance;
    public VideoPlayer videoPlayer;
    public GameObject canvasGo;
    private void Awake()
    {
        _instance = this;
    }
    // Use this for initialization
    void Start () {
        canvasGo.SetActive(false);
        videoPlayer.Play();
        Invoke("Finish",(float)videoPlayer.clip.length);
    }
    public void Finish() {
        canvasGo.SetActive(true);
        videoPlayer.Stop();
    }
	// Update is called once per frame
	void Update () {
		
	}
}

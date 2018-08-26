using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class ScenceTween : MonoBehaviour {
    public static ScenceTween _instance;
    public Transform cloud1;
    public Transform cloud2;
    public Transform tree1;
    public Transform tree2;
    private void Awake()
    {
        _instance = this;
    }
    // Use this for initialization
    void Start () {
        cloud1.DOLocalMoveX(-15,120).SetLoops(-1, LoopType.Restart).SetDelay(20);
        cloud2.DOLocalMoveX(-15,120).SetLoops(-1, LoopType.Restart);
        cloud1.DOLocalMoveY(2.3f, 10).SetLoops(-1, LoopType.Yoyo).SetDelay(2);
        cloud2.DOLocalMoveY(2.3f, 10).SetLoops(-1, LoopType.Yoyo);
        //tree1.DOLocalMoveX(-15,60).SetLoops(-1, LoopType.Restart);
        //tree1.DOLocalMoveY(1.8f,30).SetLoops(-1, LoopType.Yoyo);
        //tree2.DOLocalMoveX(-15, 60).SetLoops(-1, LoopType.Restart).SetDelay(20);
        //tree2.DOLocalMoveY(1.8f, 30).SetLoops(-1, LoopType.Yoyo).SetDelay(20);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public enum ResultType{
    win = 0,lose_popu = 1,
}
public class GameResult {
    private static GameResult _instance = null;
    private string result;
    public static GameResult GetInstance()
    {
        if (_instance == null)
        {
            _instance = new GameResult();

        }
        return _instance;
    }
    public string GetResult() {
        return result;
    }
    public void SetResult(int _result) {
        switch (_result) {
            case (int)ResultType.win :
                result = "游戏胜利";break;
            case (int)ResultType.lose_popu:
                result = "游戏失败"; break;
            default:
                result = "游戏胜利"; break;
        }
    }
}
public class GameOverMgr : MonoBehaviour {
    public static GameOverMgr _instance;

    public Text result;
    private void Awake()
    {
        _instance = this;
    }
    // Use this for initialization
    void Start () {
        result.text = GameResult.GetInstance().GetResult();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Return() {
        SceneManager.LoadScene("Login");
    }
}

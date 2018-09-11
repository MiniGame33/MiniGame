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
    private int resultNum;
    public static GameResult GetInstance()
    {
        if (_instance == null)
        {
            _instance = new GameResult();

        }
        return _instance;
    }
    public int GetResult() {
        return resultNum;
    }
    public void SetResult(int _result) {
        resultNum = _result;
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

    public List<GameObject> winList;
    public Text result;
    private int _playIndex = 0;
    private float _dely = 2;
    private void Awake()
    {
        _instance = this;
        for (int i = 0; i < winList.Count; i++)
        {
            winList[i].SetActive(false);
        }
    }
    // Use this for initialization
    void Start () {
        result.text = GameResult.GetInstance().GetResult().ToString();
        if (GameResult.GetInstance().GetResult() == (int)ResultType.win)
        {
            winList[0].SetActive(true);
            Invoke("PlayWin", _dely);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Return() {
        SceneManager.LoadScene("Login");
    }

    void PlayWin() {
        winList[_playIndex].SetActive(false);
        _playIndex++;
        if (_playIndex >= winList.Count)
        {
            return;
        }
        else
        {
            winList[_playIndex].SetActive(true);
            Invoke("PlayWin", _dely);
        }
    }
}

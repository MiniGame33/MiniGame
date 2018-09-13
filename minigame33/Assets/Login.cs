using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using LitJson;

public class Login : MonoBehaviour
{
    public GameObject nickname;
    public GameObject password;
    public GameObject startface;
    public GameObject info;
    public GameObject p1;
    public GameObject p2;
    public GameObject p3;

    void Start()
    {
        startface.SetActive(false);
        p1.SetActive(false);
        p2.SetActive(false);
        p3.SetActive(false);
    }

    void Update()
    {

    }

    IEnumerator SendPost(string _url, WWWForm _wForm)
    {
        WWW postData = new WWW(_url, _wForm);
        yield return postData;
        if (postData.error != null)
        {
            info.GetComponent<Text>().text = postData.error;
        }
        else
        {
            JsonData jsonData = JsonMapper.ToObject(postData.text);
            int ret = int.Parse(jsonData["ret"].ToString());
            string msg = jsonData["msg"].ToString();
            info.GetComponent<Text>().text = msg;
            Debug.Log(msg);
            if (msg == "succ signin")
            {
                string archive = jsonData["archive"].ToString();
                Debug.Log(archive);
                if (archive != "")
                {
                    startface.SetActive(true);
                }
                else
                {
                    startface.SetActive(true);
                    p1.SetActive(true);
                }
            }
            
        }

        
    }

    private int Check() {
        if (nickname.GetComponent<InputField>().text == "")
        {
            info.GetComponent<Text>().text = "请输入昵称";
            return -1;
        }

        if (password.GetComponent<InputField>().text == "") {
            info.GetComponent<Text>().text = "请输入密码";
            return -1;
        }

        return 0;
    }

    public void SignIn() {
        string url = "http://132.232.124.15:2333/signin/";
        WWWForm form = new WWWForm();

        if (Check() != 0) {
            return;
        }

        form.AddField("nickname", nickname.GetComponent<InputField>().text);
        form.AddField("password", password.GetComponent<InputField>().text);
        
        StartCoroutine(SendPost(url, form));
    }

    public void Signup() {
        string url = "http://132.232.124.15:2333/signup/";
        WWWForm form = new WWWForm();

        if (Check() != 0) {
            return;
        }

        form.AddField("nickname", nickname.GetComponent<InputField>().text);
        form.AddField("password", password.GetComponent<InputField>().text);

        StartCoroutine(SendPost(url, form));
    }

    public void action1() {
        p2.SetActive(true);
    }

    public void action2() {
        p3.SetActive(true);
    }

    public void action3() {
        startface.SetActive(true);
    }
}

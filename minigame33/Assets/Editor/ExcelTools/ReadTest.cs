using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
public class ReadTest : MonoBehaviour
{

    //key:表名 val 表数据列表
    Dictionary<string, List<ConfigClass>> dic = new Dictionary<string, List<ConfigClass>>();
    int loadStep = 0;

    private void Start()
    {
        StartCoroutine(ReadConfigFile("Global.msconfig"));

    }

    void LogData()
    {
        Debug.Log(JsonMapper.ToJson(dic["Global.msconfig"][0]));
    }

    IEnumerator ReadConfigFile(string filename)
    {
        loadStep++;

        string filepath = ExcelTool.GetConfigFilePath(filename);

        WWW www = new WWW(filepath);
        yield return www;
        while (www.isDone == false) yield return null;
        if (www.error == null)
        {
            byte[] data = www.bytes;
            List<ConfigClass> datalist = (List<ConfigClass>)ExcelTool.DeserializeObj(data);
            dic.Add(filename, datalist);
        }
        else
        {
            //GameLogTools.SetText("wwwError<<" + www.error + "<<" + filepath);
            Debug.Log("wwwError<<" + www.error + "<<" + filepath);
        }

        loadStep--;
        if (loadStep <= 0)
        {
            LogData();
        }
    }

}
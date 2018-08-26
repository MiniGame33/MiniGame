using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System;

public class CfgTabelMgr : MonoBehaviour {
    public static CfgTabelMgr _instance;
    int loadStep = 0;
    string fileNameStr = ".json";
    // Use this for initialization
    void Awake () {
        _instance = this;
        StartCoroutine("ReadConfigFileGlobal", "Global");
        StartCoroutine("ReadConfigFileRandomEvent", "RandomEvent");
        StartCoroutine("ReadConfigFileOption", "Option");
    }

    IEnumerator ReadConfigFileGlobal(string tablename)
    {
        loadStep++;
        string filename = tablename + fileNameStr;
        string filepath = GetConfigFilePath(filename);

        WWW www = new WWW(filepath);
        yield return www;
        while (www.isDone == false) yield return null;
        if (www.error == null)
        {
            string data = www.text;
            DeserializeGlobal cfgDeserializeClass = JsonUtility.FromJson<DeserializeGlobal>(data);
            List<ConfigClass> cfgList = new List<ConfigClass>(cfgDeserializeClass.cfgArray);
            CfgTabelData.GetInstance().WriteData(tablename, cfgList);
        }
        else
        {
            Debug.LogError("wwwError<<" + www.error + "<<" + filepath);
        }

        loadStep--;
        if (loadStep <= 0)
        {
            LoadMgr._instance.loadNum--; 
        }
    }
    IEnumerator ReadConfigFileRandomEvent(string tablename)
    {
        loadStep++;
        string filename = tablename + fileNameStr;
        string filepath = GetConfigFilePath(filename);

        WWW www = new WWW(filepath);
        yield return www;
        while (www.isDone == false) yield return null;
        if (www.error == null)
        {
            string data = www.text;
            DeserializeRandomEvent cfgDeserializeClass = JsonUtility.FromJson<DeserializeRandomEvent>(data);
            List<ConfigClass> cfgList = new List<ConfigClass>(cfgDeserializeClass.cfgArray);
            CfgTabelData.GetInstance().WriteData(tablename, cfgList);
        }
        else
        {
            Debug.LogError("wwwError<<" + www.error + "<<" + filepath);
        }

        loadStep--;
        if (loadStep <= 0)
        {
            LoadMgr._instance.loadNum--;
        }
    }
    IEnumerator ReadConfigFileOption(string tablename)
    {
        loadStep++;
        string filename = tablename + fileNameStr;
        string filepath = GetConfigFilePath(filename);

        WWW www = new WWW(filepath);
        yield return www;
        while (www.isDone == false) yield return null;
        if (www.error == null)
        {
            string data = www.text;
            DeserializeOption cfgDeserializeClass = JsonUtility.FromJson<DeserializeOption>(data);
            List<ConfigClass> cfgList = new List<ConfigClass>(cfgDeserializeClass.cfgArray);
            CfgTabelData.GetInstance().WriteData(tablename, cfgList);
        }
        else
        {
            Debug.LogError("wwwError<<" + www.error + "<<" + filepath);
        }

        loadStep--;
        if (loadStep <= 0)
        {
            LoadMgr._instance.loadNum--;
        }
    }
    public static string GetConfigFilePath(string tablename)
    {
        string src = "";

        if (Application.platform == RuntimePlatform.Android)
        {
            src = "jar:file://" + Application.dataPath + "!/assets/Config/" + tablename;
        }
        else if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            src = "file://" + Application.dataPath + "/Raw/Config/" + tablename;
        }
        else
        {
            src = "file://" + Application.streamingAssetsPath + "/Config/" + tablename;
        }
        return src;
    }
}

public class CfgTabelData
{
    public class CfgDataList {
        string tableName;
        List<ConfigClass> data;
        public void WriteData(string tabelname, List<ConfigClass> datalist) {
            this.tableName = tabelname;
            this.data = datalist;
        }
        public List<ConfigClass> getData() {
            return data;
        }
        public ConfigClass getDataByID(int _id) {
            for (int i = 0; i < data.Count; i++)
            {
                if (data[i].id == _id)
                {
                    return data[i];
                }
            }
            return null;
        }
    }
    //key:表名 val 表数据列表
    private Dictionary<string, CfgDataList> dic = new Dictionary<string, CfgDataList>();
    private static CfgTabelData _instance;
    public static CfgTabelData GetInstance() {
        if (_instance == null)
        {
            _instance = new CfgTabelData();
        }
        return _instance;
    }

    public void WriteData(string tabelname, List<ConfigClass> datalist) {
        CfgDataList cfgDataList = new CfgDataList();
        cfgDataList.WriteData(tabelname,datalist);
        dic.Add(tabelname, cfgDataList);
    }

    public CfgDataList GetCfgTabelByName(string tabelname) {
        if (dic.ContainsKey(tabelname))
            return dic[tabelname];
        else
            return null;
    }
    public void LogDataByTableName(string tablename)
    {
        CfgDataList cfg = dic[tablename];
        if (cfg == null)
        {
            Debug.LogError("配置不存在");
            return;
        }
        for (int i = 0; i < cfg.getData().Count; i++)
        {
            Debug.Log(JsonMapper.ToJson(cfg.getData()[i]));
        }
    }
}

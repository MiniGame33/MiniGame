using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;

public class CfgTabelMgr : MonoBehaviour {
    public static CfgTabelMgr _instance;
    int loadStep = 0;
    string fileNameStr = ".msconfig";
    // Use this for initialization
    void Awake () {
        _instance = this;
        StartCoroutine("ReadConfigFile", "Global");
    }

    IEnumerator ReadConfigFile(string tablename)
    {
        loadStep++;
        string filename = tablename + fileNameStr;
        string filepath = ExcelTool.GetConfigFilePath(filename);

        WWW www = new WWW(filepath);
        yield return www;
        while (www.isDone == false) yield return null;
        if (www.error == null)
        {
            byte[] data = www.bytes;
            List<ConfigClass> datalist = (List<ConfigClass>)ExcelTool.DeserializeObj(data);
            CfgTabelData.GetInstance().WriteData(tablename, datalist);
        }
        else
        {
            //GameLogTools.SetText("wwwError<<" + www.error + "<<" + filepath);
            Debug.LogError("wwwError<<" + www.error + "<<" + filepath);
        }

        loadStep--;
        if (loadStep <= 0)
        {
            CfgTabelData.GetInstance().LogDataByTableName(tablename);
        }
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
                if (data[i].id == _id.ToString())
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
        return dic[tabelname];
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

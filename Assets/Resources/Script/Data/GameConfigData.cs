using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameConfigData 
{
    List<Dictionary<string, string>> dataDic;
    public GameConfigData(string str) 
    {
        dataDic = new List<Dictionary<string, string>>();

        // 切割字符串获得对应的数据字典
        string[] Lines = str.Split('\n');
        string[] Tittle = Lines[0].Trim().Split('\t');
        for (int i = 2; i < Lines.Length; i++)
        {
            Dictionary<string, string> newDic = new Dictionary<string, string>();
            string[] tmp = Lines[i].Trim().Split("\t");
            for (int j = 0; j < tmp.Length; j++)
            {
                newDic.Add(Tittle[j], tmp[j]);
            }
            dataDic.Add(newDic);
        }
        
    }
    // 获得数据表
    public List<Dictionary<string, string>> getDataList()
    {
        return dataDic;
    }
    // 获得指定数据
    public Dictionary<string, string> getDataDicById(string Id)
    {
        for (int i = 0; i < dataDic.Count; i++)
        {
            Dictionary<string, string> Dic = dataDic[i];    
            if (Dic["Id"] == Id)
            {
                return Dic;
            }
        }
        return null;
    }
}

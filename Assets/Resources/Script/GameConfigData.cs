using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameConfigData 
{
    List<Dictionary<string, string>> dataDic;
    public GameConfigData(string str) 
    {
        dataDic = new List<Dictionary<string, string>>();

        // �и��ַ�����ö�Ӧ�������ֵ�
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
    // ������ݱ�
    public List<Dictionary<string, string>> getDataList()
    {
        return dataDic;
    }
    // ���ָ������
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

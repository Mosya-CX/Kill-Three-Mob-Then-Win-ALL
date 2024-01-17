using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameConfigManager
{
    public static GameConfigManager Instance = new GameConfigManager();
    // �������ݱ�
    GameConfigData cardData;
    // �������ݱ�
    GameConfigData enemyData;

    TextAsset textAsset;

    // ��ʼ�������ļ�
    public void Init()
    {
        textAsset = Resources.Load<TextAsset>("Data/card");
        cardData = new GameConfigData(textAsset.text);
        //textAsset = Resources.Load<TextAsset>("Data/enemy");
        //enemyData = new GameConfigData(textAsset.text);
    }

    // ������ݱ�
    public List<Dictionary<string, string>> getCardData()
    {
        return cardData.getDataList();
    }
    public List<Dictionary<string, string>> getEnemyData()
    {
        return enemyData.getDataList();
    }
    // ���ָ��id���ֵ�
    public Dictionary<string, string> getCardById(string Id)
    {
        return cardData.getDataDicById(Id); 
    }
    public Dictionary<string, string> getEnemyById(string Id)
    {
        return enemyData.getDataDicById(Id);
    }
}

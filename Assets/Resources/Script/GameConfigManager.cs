using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameConfigManager
{
    public static GameConfigManager Instance = new GameConfigManager();
    // 卡牌数据表
    GameConfigData cardData;
    // 敌人数据表
    GameConfigData enemyData;

    TextAsset textAsset;

    // 初始化配置文件
    public void Init()
    {
        textAsset = Resources.Load<TextAsset>("Data/card");
        cardData = new GameConfigData(textAsset.text);
        //textAsset = Resources.Load<TextAsset>("Data/enemy");
        //enemyData = new GameConfigData(textAsset.text);
    }

    // 获得数据表
    public List<Dictionary<string, string>> getCardData()
    {
        return cardData.getDataList();
    }
    public List<Dictionary<string, string>> getEnemyData()
    {
        return enemyData.getDataList();
    }
    // 获得指定id的字典
    public Dictionary<string, string> getCardById(string Id)
    {
        return cardData.getDataDicById(Id); 
    }
    public Dictionary<string, string> getEnemyById(string Id)
    {
        return enemyData.getDataDicById(Id);
    }
}

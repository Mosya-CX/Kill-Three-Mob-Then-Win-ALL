using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfoManager
{
    public static PlayerInfoManager Instance = new PlayerInfoManager();
    // 存储手牌
    public List<string> handCards;
    //// 设置初始手牌(这个在我们游戏好像没用)
    //public void Init()
    //{
    //    handCards = new List<string>();
    //    // 例：handCards.Add("卡牌id");
    //}


}

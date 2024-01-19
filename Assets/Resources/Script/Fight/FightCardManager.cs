using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86.Avx;
using TMPro;

public class FightCardManager
{
    public static FightCardManager instance = new FightCardManager();

    // 可用牌堆
    List<string> availableCardList;
    // 弃牌堆
    List<string> usedCardList;

    public TMP_Text cardCountText;   //现有手牌数量
    public TMP_Text usedCardCountText;    //弃牌堆数量

    // 战斗开始初始化手牌
    public void Init()
    {
        availableCardList = new List<string>();
        usedCardList = new List<string>();
        // 临时牌堆
        List<string> temp = PlayerInfoManager.Instance.handCards;
        // 清空手牌
        while (temp.Count > 0)
        {
            // 随机抽取临时牌堆里的牌
            int cardIndex = Random.Range(0, temp.Count-1);
            // 添加到可用牌堆
            availableCardList.Add(temp[cardIndex]);
            // 删除临时牌堆里的目标牌
            temp.RemoveAt(cardIndex);
        }
        // 将弃牌区的牌放回可用牌堆
        while (usedCardList.Count > 0)
        {
            
            int cardIndex = Random.Range(0, usedCardList.Count - 1);
            
            availableCardList.Add(usedCardList[cardIndex]);
            
            usedCardList.RemoveAt(cardIndex);
        }
    }
    // 检测牌堆是否有牌
    public bool hasCard()
    {
        return availableCardList.Count > 0;
    }
    // 抽卡
    public string DrawCard()
    {
        string id = availableCardList[availableCardList.Count-1];
        availableCardList.RemoveAt(availableCardList.Count-1);
        return id;
    }
}

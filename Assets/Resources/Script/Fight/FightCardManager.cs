using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86.Avx;
using TMPro;

public class FightCardManager
{
    public static FightCardManager instance = new FightCardManager();

    // 可用牌堆
    public List<string> availableCardList;
    // 弃牌堆
    public List<string> usedCardList;

    public TMP_Text cardCountText;   //现有手牌数量
    public TMP_Text usedCardCountText;    //弃牌堆数量

    // 战斗开始初始化手牌
    public void Init()
    {
        availableCardList = new List<string>() { "1000", "1000", "1000", "1002", "1002", "1002", "1002", "1002", "1003", "1005", "1004", "1011", "1008", "1014" };
        usedCardList = new List<string>();

        // 清空手牌
        ResetHandCard();
        // 将弃牌区的牌放回可用牌堆
        ResetUsedCard();
        // 随机洗牌
        ShuffleCards();
    }
    // 清空手牌
    public void ResetHandCard()
    {
        // 临时牌堆
        List<string> temp = PlayerInfoManager.Instance.handCards;
        // 清空手牌
        while (temp.Count > 0)
        {
            // 随机抽取临时牌堆里的牌
            int cardIndex = Random.Range(0, temp.Count - 1);
            // 添加到可用牌堆
            availableCardList.Add(temp[cardIndex]);
            // 删除临时牌堆里的目标牌
            temp.RemoveAt(cardIndex);
        }
    }

    // 将弃牌区的牌放回可用牌堆
    public void ResetUsedCard()
    {
        while (usedCardList.Count > 0)
        {
            Debug.Log(2);

            int cardIndex = Random.Range(0, usedCardList.Count);

            availableCardList.Add(usedCardList[cardIndex]);

            usedCardList.RemoveAt(cardIndex);

            Debug.Log(3);
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
        if (availableCardList.Count > 0)
        {
            int index = Random.Range(0, availableCardList.Count);
            string id = availableCardList[index];
            availableCardList.RemoveAt(index);
            return id;
        }
        else
        {
            Debug.Log("卡池为空");
            return null;
        }
    }

    // 随机洗牌
    public void ShuffleCards()
    {
        int n = availableCardList.Count;
        while (n > 1)
        {
            // 选择一个随机索引
            int k = Random.Range(0, n--);
            // 交换
            string tmp = availableCardList[n];
            availableCardList[n] = availableCardList[k];
            availableCardList[k] = tmp;
        }

    }
}

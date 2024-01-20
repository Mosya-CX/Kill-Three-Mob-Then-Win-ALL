using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FightUI : BasePanel
{
    private Text cardNumTxt;//卡牌数量
    private Text usedCardNumTxt;//弃牌堆数量


    private void Awake()
    {
        cardNumTxt = transform.Find("hasCard/icon/Text").GetComponent<Text>();
        usedCardNumTxt = transform.Find("noCard/icon/Text").GetComponent<Text>();

    }

    private void Start()
    {
        UpdateCardNum();
        updateUsedCardNum();
    }



    //更新卡堆数量
    public void UpdateCardNum()
    {
        cardNumTxt.text = FightCardManager.instance.availableCardList.Count.ToString();
    }

    //更新弃牌堆数量
    public void updateUsedCardNum()
    {
        usedCardNumTxt.text = FightCardManager.instance.usedCardList.Count.ToString();
    }
}

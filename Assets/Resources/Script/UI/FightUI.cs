using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FightUI : BasePanel
{
    private Text cardNumTxt;//卡牌数量
    private Text usedCardNumTxt;//弃牌堆数量
    private Text feeTxt;//费用数值
    private Text hpTxt;//血量数值
    private Image hpImg;//血条
    private Text defenseTxt;//防御数值

    private void Awake()
    {
        cardNumTxt = transform.Find("Card/CardNumText").GetComponent<Text>();
        usedCardNumTxt = transform.Find("UsedCard/UsedCardNumText").GetComponent<Text>();
        feeTxt = transform.Find("Fee/FeeCountText").GetComponent<Text>();
        hpTxt = transform.Find("playerHP/playerHPText").GetComponent<Text>();
        hpImg = transform.Find("playerHP/playerHP_Image").GetComponent<Image>();
        defenseTxt = transform.Find("Shield/playerShieldText").GetComponent<Text>();

    }
}

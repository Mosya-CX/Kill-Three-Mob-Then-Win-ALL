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
        cardNumTxt = transform.Find("hasCard/icon/Text").GetComponent<Text>();
        usedCardNumTxt = transform.Find("noCard/icon/Text").GetComponent<Text>();
        feeTxt = transform.Find("mana/Text").GetComponent<Text>();
        hpTxt = transform.Find("hp/hpText").GetComponent<Text>();
        hpImg = transform.Find("hp/fill").GetComponent<Image>();
        defenseTxt = transform.Find("hp/fangyu/Text").GetComponent<Text>();

    }
    private void Start()
    {
        UpdateHp();
        UpdateFee();
        UpdateDefense();
        UpdateCardNum();
        updateUsedCardNum();
    }
    //更新血量显示
    public void UpdateHp()
    {
        hpTxt.text = FightManager.Instance.curHp + "/" + FightManager.Instance.maxHp;
        hpImg.fillAmount = (float)FightManager.Instance.curHp / (float)FightManager.Instance.maxHp;
    }

    //更新费用
    public void UpdateFee()
    {
        feeTxt.text = FightManager.Instance.curFee + "/" + FightManager.Instance.maxFee;
    }

    //更新防御值
    public void UpdateDefense()
    {
        defenseTxt.text = FightManager.Instance.defenseCount.ToString();
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FightUI : BasePanel
{
    private Text cardNumTxt;//��������
    private Text usedCardNumTxt;//���ƶ�����
    private Text feeTxt;//������ֵ
    private Text hpTxt;//Ѫ����ֵ
    private Image hpImg;//Ѫ��
    private Text defenseTxt;//������ֵ

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
    //����Ѫ����ʾ
    public void UpdateHp()
    {
        hpTxt.text = FightManager.Instance.curHp + "/" + FightManager.Instance.maxHp;
        hpImg.fillAmount = (float)FightManager.Instance.curHp / (float)FightManager.Instance.maxHp;
    }

    //���·���
    public void UpdateFee()
    {
        feeTxt.text = FightManager.Instance.curFee + "/" + FightManager.Instance.maxFee;
    }

    //���·���ֵ
    public void UpdateDefense()
    {
        defenseTxt.text = FightManager.Instance.defenseCount.ToString();
    }

    //���¿�������
    public void UpdateCardNum()
    {
        cardNumTxt.text = FightCardManager.instance.availableCardList.Count.ToString();
    }

    //�������ƶ�����
    public void updateUsedCardNum()
    {
        usedCardNumTxt.text = FightCardManager.instance.usedCardList.Count.ToString();
    }
}

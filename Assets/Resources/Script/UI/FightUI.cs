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
        cardNumTxt = transform.Find("Card/CardNumText").GetComponent<Text>();
        usedCardNumTxt = transform.Find("UsedCard/UsedCardNumText").GetComponent<Text>();
        feeTxt = transform.Find("Fee/FeeCountText").GetComponent<Text>();
        hpTxt = transform.Find("playerHP/playerHPText").GetComponent<Text>();
        hpImg = transform.Find("playerHP/playerHP_Image").GetComponent<Image>();
        defenseTxt = transform.Find("Shield/playerShieldText").GetComponent<Text>();

    }
}

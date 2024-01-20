using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FightUI : BasePanel
{
    private Text cardNumTxt;//��������
    private Text usedCardNumTxt;//���ƶ�����


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

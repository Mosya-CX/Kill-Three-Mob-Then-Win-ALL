using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86.Avx;
using TMPro;

public class FightCardManager
{
    public static FightCardManager instance = new FightCardManager();

    // �����ƶ�
    public List<string> availableCardList;
    // ���ƶ�
    public List<string> usedCardList;

    public TMP_Text cardCountText;   //������������
    public TMP_Text usedCardCountText;    //���ƶ�����

    // ս����ʼ��ʼ������
    public void Init()
    {
        availableCardList = new List<string>();
        usedCardList = new List<string>();
        // ��ʱ�ƶ�
        List<string> temp = PlayerInfoManager.Instance.handCards;
        // �������
        while (temp.Count > 0)
        {
            // �����ȡ��ʱ�ƶ������
            int cardIndex = Random.Range(0, temp.Count-1);
            // ��ӵ������ƶ�
            availableCardList.Add(temp[cardIndex]);
            // ɾ����ʱ�ƶ����Ŀ����
            temp.RemoveAt(cardIndex);
        }
        // �����������ƷŻؿ����ƶ�
        ResetUsedCard();
    }
    // �����������ƷŻؿ����ƶ�
    public void ResetUsedCard()
    {
        while (usedCardList.Count > 0)
        {
            Debug.Log(2);

            int cardIndex = Random.Range(0, usedCardList.Count - 1);

            availableCardList.Add(usedCardList[cardIndex]);

            usedCardList.RemoveAt(cardIndex);

            Debug.Log(3);
        }
    }

    // ����ƶ��Ƿ�����
    public bool hasCard()
    {
        return availableCardList.Count > 0;
    }
    // �鿨
    public string DrawCard()
    {
        string id = availableCardList[Random.Range(0, availableCardList.Count - 1)];
        availableCardList.RemoveAt(availableCardList.Count-1);
        return id;
    }
}

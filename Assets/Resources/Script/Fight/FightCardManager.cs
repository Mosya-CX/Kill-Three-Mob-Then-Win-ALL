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
        availableCardList = new List<string>() { "1000", "1000", "1000", "1002", "1002", "1002", "1002", "1002", "1003", "1005", "1004", "1011", "1008", "1014" };
        usedCardList = new List<string>();

        // �������
        ResetHandCard();
        // �����������ƷŻؿ����ƶ�
        ResetUsedCard();
        // ���ϴ��
        ShuffleCards();
    }
    // �������
    public void ResetHandCard()
    {
        // ��ʱ�ƶ�
        List<string> temp = PlayerInfoManager.Instance.handCards;
        // �������
        while (temp.Count > 0)
        {
            // �����ȡ��ʱ�ƶ������
            int cardIndex = Random.Range(0, temp.Count - 1);
            // ��ӵ������ƶ�
            availableCardList.Add(temp[cardIndex]);
            // ɾ����ʱ�ƶ����Ŀ����
            temp.RemoveAt(cardIndex);
        }
    }

    // �����������ƷŻؿ����ƶ�
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

    // ����ƶ��Ƿ�����
    public bool hasCard()
    {
        return availableCardList.Count > 0;
    }
    // �鿨
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
            Debug.Log("����Ϊ��");
            return null;
        }
    }

    // ���ϴ��
    public void ShuffleCards()
    {
        int n = availableCardList.Count;
        while (n > 1)
        {
            // ѡ��һ���������
            int k = Random.Range(0, n--);
            // ����
            string tmp = availableCardList[n];
            availableCardList[n] = availableCardList[k];
            availableCardList[k] = tmp;
        }

    }
}

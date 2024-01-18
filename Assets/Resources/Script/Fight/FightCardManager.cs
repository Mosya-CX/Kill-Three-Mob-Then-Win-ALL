using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightCardManager
{
    public static FightCardManager instance = new FightCardManager();

    // �����ƶ�
    List<string> availableCardList;
    // ���ƶ�
    List<string> usedCardList;
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
        while (usedCardList.Count > 0)
        {
            
            int cardIndex = Random.Range(0, usedCardList.Count - 1);
            
            availableCardList.Add(usedCardList[cardIndex]);
            
            usedCardList.RemoveAt(cardIndex);
        }
        // ���³�ȡ6��
        while (temp.Count < 6)
        {
            
            int cardIndex = Random.Range(0, availableCardList.Count - 1);
            
            temp.Add(availableCardList[cardIndex]);
            
            temp.RemoveAt(cardIndex);
        }
    }


}

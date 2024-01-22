using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//��Ҷ���			�ظ�20Ѫ���ڱ���ʣ��ʱ���ڣ�ÿ�غ϶��2����

public class Card1016 : CardItem
{
    public override void OnPointerClick(PointerEventData eventData)
    {
        if (!isSlectable)
        {
            FightCardManager.instance.availableCardList.Add(data["Id"]);
            GameObject.Find("UI/CardSelectUI").GetComponent<CardSelectUI>().progress++;
            GameObject.Find("UI/CardSelectUI").GetComponent<CardSelectUI>().isReCreate = false;
            return;
        }

        if (TryUse())
        {
            
            GameManager.Instance.player.curHP += 15;
            // ʣ��ʱ����ÿ�غ϶��2���� ��Ҫ��PlayerTurn�ĳ�����

        }

        base.OnPointerClick(eventData);
    }
}

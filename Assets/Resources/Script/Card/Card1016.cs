using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//��Ҷ���			�ظ�15Ѫ������ս��ʣ��ʱ����ÿ�غ϶��2����

public class Card1016 : CardItem
{
    public override void OnPointerClick(PointerEventData eventData)
    {
        if (TryUse())
        {
            GameManager.Instance.player.curHP += 15;
            // ʣ��ʱ����ÿ�غ϶��2���� ��Ҫ��PlayerTurn�ĳ�����

        }

        base.OnPointerClick(eventData);
    }
}

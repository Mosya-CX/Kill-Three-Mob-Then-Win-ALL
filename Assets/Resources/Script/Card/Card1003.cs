using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

//���ٷ��� ���12���
public class Card1003 : CardItem
{
    public override void OnPointerClick(PointerEventData eventData)
    {
        if (TryUse())
        {
            // ʹ��Ч��
            GameManager.Instance.player.Shield += 12;

            base.OnPointerClick(eventData);
        }

   
    }

}

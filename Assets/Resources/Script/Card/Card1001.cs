using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
//����			����4�㻤��
public class Card1001 : CardItem
{
    public override void OnPointerClick(PointerEventData eventData)
    {

        if (TryUse())
        {
            //��������
            AudioManager.Instance.ArmorAudio();

            // ʹ��Ч��
            GameManager.Instance.player.Shield += 4;

            base.OnPointerClick(eventData);
        }
        
    }
}

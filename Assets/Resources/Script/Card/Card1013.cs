using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//����			���8�㻤�ܣ��ڱ���ʣ��ʱ���ڣ�ʹ�������ϴ��ڲ������ĵ�ˮԪ�ظ���
public class Card1013 : CardItem
{
    public override void OnPointerClick(PointerEventData eventData)
    {
        if (TryUse())
        {
            // ʹ��Ч��
            GameManager.Instance.player.Shield += 8;
            BuffManager.Instance.AddBuff(GameManager.Instance.enemy.gameObject, 3001);


            base.OnPointerClick(eventData);
        }
        
    }
}

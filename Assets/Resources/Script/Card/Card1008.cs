using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//��			���10���Ԫ���˺������������һ����ɵ��˺���Ϊ��Ԫ���˺�

public class Card1008 : CardItem
{
    public override void OnPointerClick(PointerEventData eventData)
    {
        if (TryUse())
        {
            //ʹ��Ч��
            if (GameManager.Instance.enemy.Shield >= 10)
            {
                GameManager.Instance.enemy.Shield -= 10;
            }
            else if (GameManager.Instance.enemy.Shield < 10 && GameManager.Instance.enemy.Shield > 0)
            {
                GameManager.Instance.enemy.curHP -= (10 - GameManager.Instance.enemy.Shield);
                GameManager.Instance.enemy.Shield = 0;
            }
            else
            {
                GameManager.Instance.enemy.curHP -= 10;
            }
            BuffManager.Instance.AddBuff(GameManager.Instance.enemy.gameObject, 3000);

            base.OnPointerClick(eventData);
        }

        
    }
}

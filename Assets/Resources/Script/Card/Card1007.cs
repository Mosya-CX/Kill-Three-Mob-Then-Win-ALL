using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//����������			�ڱ��ֶ�սʣ��ʱ���ڣ������Լ���1��������ޣ�ÿ�غϿ�ʼʱ�Ե������������һ��Ԫ�ص�1���˺�
public class Card1007 : CardItem
{
    public override void OnPointerClick(PointerEventData eventData)
    {
        if (TryUse())
        {
            // ʹ��Ч��
            GameManager.Instance.player.totalFee += 1;

            if (GameManager.Instance.enemy.Shield >= 1)
            {
                GameManager.Instance.enemy.Shield -= 1;
            }
            else if (GameManager.Instance.enemy.Shield < 1 && GameManager.Instance.enemy.Shield > 0)
            {
                GameManager.Instance.enemy.curHP -= (1 - GameManager.Instance.enemy.Shield);
                GameManager.Instance.enemy.Shield = 0;
            }
            else
            {
                GameManager.Instance.enemy.curHP -= 1;
            }

            BuffManager.Instance.AddBuff(GameManager.Instance.enemy.gameObject, Random.Range(3000, 3002));

            base.OnPointerClick(eventData);
        }

        
    }
}

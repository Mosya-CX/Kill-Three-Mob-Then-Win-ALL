using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//��			���7���Ԫ���˺������غϽ����Ե������1���Ԫ���˺�


public class Card1008 : CardItem
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
            //ʹ��Ч��
            //����˺�
            if (GameManager.Instance.enemy.Shield >= 7)
            {
                GameManager.Instance.enemy.Shield -= 7;
            }
            else if (GameManager.Instance.enemy.Shield < 7 && GameManager.Instance.enemy.Shield > 0)
            {
                GameManager.Instance.enemy.curHP -= (7 - GameManager.Instance.enemy.Shield);
                GameManager.Instance.enemy.Shield = 0;
            }
            else
            {
                GameManager.Instance.enemy.curHP -= 7;
            }
            // ��buff
            BuffManager.Instance.AddBuff(GameManager.Instance.enemy.gameObject, 3000);
            // ���غϽ����Ե������1���Ԫ���˺�
            

            base.OnPointerClick(eventData);
        }

        
    }
}

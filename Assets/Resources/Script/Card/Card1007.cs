using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//����������			�ڱ��ֶ�սʣ��ʱ���ڣ������Լ���1��������ޣ�ÿ�غϿ�ʼʱ�Ե������������һ��Ԫ�ص�1���˺�
public class Card1007 : CardItem
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
            Debug.Log("1007");
            // ʹ��Ч��
            GameManager.Instance.player.totalFee += 1;// ��߷�������
            // ����˺�
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

            // ��buff
            BuffManager.Instance.AddBuff(GameManager.Instance.enemy.gameObject, Random.Range(3000, 3003));

            base.OnPointerClick(eventData);
        }

        
    }
}

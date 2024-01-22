using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//��֮����			���10��ľ�����˺����»غ϶�����2����ò���2����
public class Card1015 : CardItem
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
            // ��buff
            BuffManager.Instance.AddBuff(GameManager.Instance.enemy.gameObject, 3002);
            // �»غ϶�����2�����
            //BuffManager.Instance.AddBuff(GameManager.Instance.enemy.gameObject, 3002);

            // �»غ϶����2����

            base.OnPointerClick(eventData);
        }
        
    }
}

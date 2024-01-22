using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//��ˮ			���3��ˮԪ���˺�����ʹ�乥��������3��
public class Card1011 : CardItem
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
            // ʹ��Ч��
            if (GameManager.Instance.enemy.Shield >= 3)
            {
                GameManager.Instance.enemy.Shield -= 3;
            }
            else if (GameManager.Instance.enemy.Shield < 3 && GameManager.Instance.enemy.Shield > 0)
            {
                GameManager.Instance.enemy.curHP -= (3 - GameManager.Instance.enemy.Shield);
                GameManager.Instance.enemy.Shield = 0;
            }
            else
            {
                GameManager.Instance.enemy.curHP -= 3;
            }

            GameManager.Instance.enemy.baseDamage -= 3;
            BuffManager.Instance.AddBuff(GameManager.Instance.enemy.gameObject, 3001);

            base.OnPointerClick(eventData);
        }
        
    }
}

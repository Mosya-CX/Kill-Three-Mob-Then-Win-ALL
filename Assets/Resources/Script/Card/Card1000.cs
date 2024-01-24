using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

//���			��� 5 ���˺�
public class Card1000 : CardItem
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
            Debug.Log("1000");
            //������Ч

            //���ŵ���������Ч
            AudioManager.Instance.AttackAudio();


            // ʹ��Ч��
            if (GameManager.Instance.enemy.Shield >= 5)
            {
                GameManager.Instance.enemy.Shield -= 5;
            }
            else if (GameManager.Instance.enemy.Shield < 5 && GameManager.Instance.enemy.Shield > 0)
            {
                GameManager.Instance.enemy.curHP -= (5 - GameManager.Instance.enemy.Shield);
                GameManager.Instance.enemy.Shield = 0;
            }
            else
            {
                GameManager.Instance.enemy.curHP -= 5;
            }


            base.OnPointerClick(eventData);
        }

    }
}

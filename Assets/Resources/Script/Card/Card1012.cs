using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//ˮ֮����			���13��񵲣����ڻغϽ������3��ˮԪ���˺�
public class Card1012 : CardItem
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
            GameManager.Instance.player.Shield += 13;

            // ��buff


            //if (GameManager.Instance.enemy.Shield >= 3)
            //{
            //    GameManager.Instance.enemy.Shield -= 3;
            //}
            //else if (GameManager.Instance.enemy.Shield < 3 && GameManager.Instance.enemy.Shield > 0)
            //{
            //    GameManager.Instance.enemy.curHP -= (3 - GameManager.Instance.enemy.Shield);
            //    GameManager.Instance.enemy.Shield = 0;
            //}
            //else
            //{
            //    GameManager.Instance.enemy.curHP -= 3;
            //}

            base.OnPointerClick(eventData);
        }
        
    }
}

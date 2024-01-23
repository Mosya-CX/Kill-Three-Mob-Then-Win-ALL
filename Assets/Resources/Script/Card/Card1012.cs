using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//水之屏障	获得13点格挡，并在回合结束造成3点水元素伤害

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
           
            // 效果
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

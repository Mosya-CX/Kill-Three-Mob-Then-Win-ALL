using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//浊流	获得20点格挡，在本局剩余时间内，使敌人身上存在不会消耗的水元素附着

public class Card1013 : CardItem
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
            GameManager.Instance.player.Shield += 8;
            // buff
            //BuffManager.Instance.AddBuff(GameManager.Instance.enemy.gameObject, 3005);


            base.OnPointerClick(eventData);
        }
        
    }
}

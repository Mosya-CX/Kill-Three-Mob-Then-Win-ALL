using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//落叶归根	回复20血，在本局剩余时间内，每回合多抽2张牌

public class Card1016 : CardItem
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
            
            GameManager.Instance.player.curHP += 15;
            GameManager.Instance.player.cardCount += 2;

            base.OnPointerClick(eventData);
        }

        
    }
}

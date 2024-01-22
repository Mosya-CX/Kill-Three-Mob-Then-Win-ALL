using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//落叶归根			回复15血，本场战斗剩余时间内每回合多抽2张牌

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
            // 剩余时间内每回合多抽2张牌 需要改PlayerTurn的抽牌数

        }

        base.OnPointerClick(eventData);
    }
}

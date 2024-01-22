using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//攻守兼备			造成12点伤害，获得12点格挡
public class Card1005 : CardItem
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
            // 使用效果
            GameManager.Instance.player.Shield += 12;
            if (GameManager.Instance.enemy.Shield >= 12)
            {
                GameManager.Instance.enemy.Shield -= 12;
            }
            else if (GameManager.Instance.enemy.Shield < 12 && GameManager.Instance.enemy.Shield > 0)
            {
                GameManager.Instance.enemy.curHP -= (12 - GameManager.Instance.enemy.Shield);
                GameManager.Instance.enemy.Shield = 0;
            }
            else
            {
                GameManager.Instance.enemy.curHP -= 12;
            }


            base.OnPointerClick(eventData);
        }
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//火花			造成10点火元素伤害，并将你的下一次造成的伤害视为火元素伤害

public class Card1008 : CardItem
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
            //使用效果
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
            BuffManager.Instance.AddBuff(GameManager.Instance.enemy.gameObject, 3000);

            base.OnPointerClick(eventData);
        }

        
    }
}

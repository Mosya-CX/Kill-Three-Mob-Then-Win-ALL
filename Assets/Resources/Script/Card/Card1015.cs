using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//草之呼吸			造成10点木属性伤害，下回合额外获得2点费用并抽2张牌
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
            // 造成伤害
            if(GameManager.Instance.enemy.Shield >= 10)
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
            // 加buff
            BuffManager.Instance.AddBuff(GameManager.Instance.enemy.gameObject, 3002);
            // 下回合额外获得2点费用
            //BuffManager.Instance.AddBuff(GameManager.Instance.enemy.gameObject, 3002);

            // 下回合额外抽2张牌

            base.OnPointerClick(eventData);
        }
        
    }
}

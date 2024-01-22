using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//点水			造成3点水元素伤害，并使其攻击力减少3点
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
            // 使用效果
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

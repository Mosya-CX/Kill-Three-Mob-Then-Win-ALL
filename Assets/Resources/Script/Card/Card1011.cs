using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//点水			造成3点水元素伤害，获得5点格挡
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
            Debug.Log("1011");
            // 使用效果
            // 造成伤害
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
            // 加盾
            GameManager.Instance.player.Shield += 5;
            // 加buff
            BuffManager.Instance.AddBuff(GameManager.Instance.enemy.gameObject, 3001);

            base.OnPointerClick(eventData);
        }
        
    }
}

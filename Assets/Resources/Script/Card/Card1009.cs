using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

// 火之意志			造成20点火元素伤害
public class Card1009 : CardItem
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
            //播放特效
            GameManager.Instance.player.animator.SetTrigger("Fire");

            Debug.Log("1009");
            //使用效果
            // 造成伤害
            if (GameManager.Instance.enemy.Shield >= 20)
            {
                GameManager.Instance.enemy.Shield -= 20;
            }
            else if (GameManager.Instance.enemy.Shield < 20 && GameManager.Instance.enemy.Shield > 0)
            {
                GameManager.Instance.enemy.curHP -= (20 - GameManager.Instance.enemy.Shield);
                GameManager.Instance.enemy.Shield = 0;
            }
            else
            {
                GameManager.Instance.enemy.curHP -= 20;
            }

            //if (GameManager.Instance.player.Shield >= 5)
            //{
            //    GameManager.Instance.player.Shield -= 5;
            //}
            //else if (GameManager.Instance.player.Shield < 5 && GameManager.Instance.player.Shield > 0)
            //{
            //    GameManager.Instance.player.curHP -= (5 - GameManager.Instance.player.Shield);
            //    GameManager.Instance.player.Shield = 0;
            //}
            //else
            //{
            //    GameManager.Instance.player.curHP -= 5;
            //}
            // 加buff
            BuffManager.Instance.AddBuff(GameManager.Instance.enemy.gameObject, 3000);

            base.OnPointerClick(eventData);
        }
        
    }
}

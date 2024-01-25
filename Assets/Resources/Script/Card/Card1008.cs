using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//火花			造成7点火元素伤害，本回合结束对敌人造成1点火元素伤害


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
            Debug.Log("1008");

            //播放特效
            GameManager.Instance.player.animator.SetTrigger("Fire");

            //使用效果
            //造成伤害
            if (GameManager.Instance.enemy.Shield >= 7)
            {
                GameManager.Instance.enemy.Shield -= 7;
            }
            else if (GameManager.Instance.enemy.Shield < 7 && GameManager.Instance.enemy.Shield > 0)
            {
                GameManager.Instance.enemy.curHP -= (7 - GameManager.Instance.enemy.Shield);
                GameManager.Instance.enemy.Shield = 0;
            }
            else
            {
                GameManager.Instance.enemy.curHP -= 7;
            }
            // 加buff
            BuffManager.Instance.AddBuff(GameManager.Instance.enemy.gameObject, 3000);
            // 本回合结束对敌人造成1点火元素伤害
            BuffManager.Instance.AddBuff(GameManager.Instance.enemy.gameObject, 3003);

            base.OnPointerClick(eventData);
        }

        
    }
}

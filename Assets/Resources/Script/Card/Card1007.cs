using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//启动！！！			在本局对战剩余时间内，提升自己的1点费用上限，每回合开始时对敌人造成随机随机一个元素的1点伤害
public class Card1007 : CardItem
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
            Debug.Log("1007");
            // 使用效果
            GameManager.Instance.player.totalFee += 1;// 提高费用上线
            // 造成伤害
            if (GameManager.Instance.enemy.Shield >= 1)
            {
                GameManager.Instance.enemy.Shield -= 1;
            }
            else if (GameManager.Instance.enemy.Shield < 1 && GameManager.Instance.enemy.Shield > 0)
            {
                GameManager.Instance.enemy.curHP -= (1 - GameManager.Instance.enemy.Shield);
                GameManager.Instance.enemy.Shield = 0;
            }
            else
            {
                GameManager.Instance.enemy.curHP -= 1;
            }

            // 加buff
            BuffManager.Instance.AddBuff(GameManager.Instance.enemy.gameObject, Random.Range(3000, 3003));

            base.OnPointerClick(eventData);
        }

        
    }
}

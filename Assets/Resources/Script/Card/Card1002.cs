using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//迅捷攻击			造成 7点伤害，抽1张牌
public class Card1002 : CardItem
{
    public override void OnPointerClick(PointerEventData eventData)
    {
        if (TryUse())
        {
            //音效
            AudioManager.Instance.AttackAudio();
            // 使用效果
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

            //抽卡效果
            if (FightCardManager.instance.hasCard() == true)
            {
                UIManager.Instance.GetUI<FightUI>("FightUI").CreateCardItem(1);

            }

            base.OnPointerClick(eventData);
        }


    }
}

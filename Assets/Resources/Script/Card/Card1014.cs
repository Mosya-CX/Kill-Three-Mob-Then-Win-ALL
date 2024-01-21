using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//起草			造成6点木元素伤害，你的下个回合额外抽2张牌
public class Card1014 : CardItem
{

    public override void OnPointerClick(PointerEventData eventData)
    {

        if (TryUse())
        {
            // 使用效果
            GameManager.Instance.enemy.curHP -= 6;
            BuffManager.Instance.AddBuff(GameManager.Instance.enemy.gameObject, 3002);
            // 下回合额外抽做不到
            //抽卡效果
            if (FightCardManager.instance.hasCard() == true)
            {
                CardItem item = UIManager.Instance.GetUI<FightUI>("FightUI").CreateCardItem(2, true);
            }

            base.OnPointerClick(eventData);
        }
        
    }
}

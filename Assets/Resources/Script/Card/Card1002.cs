using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//迅捷攻击			造成 7点伤害，抽1张牌
public class Card1002 : CardItem
{
    public override void OnPointerClick(PointerEventData eventData)
    {
        if(TryUse()==true) 
        {




            //抽卡效果
            if(FightCardManager.instance.hasCard() == true) 
            {
                UIManager.Instance.GetUI<FightUI>("FightUI").CreateCardItem(1);

            }
        }
        base.OnPointerClick(eventData);
    }
}

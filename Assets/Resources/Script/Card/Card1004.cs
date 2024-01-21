using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//定向检索			抽两张牌
public class Card1004 : CardItem
{
    public override void OnPointerClick(PointerEventData eventData)
    {
        // 使用效果
        if (TryUse() == true)
        {

            //抽卡效果
            if (FightCardManager.instance.hasCard() == true)
            {
                UIManager.Instance.GetUI<FightUI>("FightUI").CreateCardItem(2, true);

            }

            base.OnPointerClick(eventData);
        }

        
    }
}

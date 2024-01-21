using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//我没意见			抽3张牌,其中一张免费
public class Card1006 : CardItem
{
    public override void OnPointerClick(PointerEventData eventData)
    {
        // 使用效果
        if (TryUse() == true)
        {


            //抽卡效果
            if (FightCardManager.instance.hasCard() == true)
            {
                CardItem item = UIManager.Instance.GetUI<FightUI>("FightUI").CreateCardItem(2, true);
                item.cost = 0;
            }
            base.OnPointerClick(eventData);
        }

        
    }
}

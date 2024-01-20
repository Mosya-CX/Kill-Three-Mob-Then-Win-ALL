using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//浴火重生			当你阵亡时，复活并永久减少10点生命上限，回复100%血量,抽一张牌
public class Card1010 : CardItem
{
    public override void OnPointerClick(PointerEventData eventData)
    {
      
        
        if (TryUse() == true)
        {
            // 使用效果
            BuffManager.Instance.AddBuff(GameManager.Instance.player.gameObject, 3004);
            

            //抽卡效果
            if (FightCardManager.instance.hasCard() == true)
            {
                CardItem item = UIManager.Instance.GetUI<FightUI>("FightUI").CreateCardItem(2);
                item.cost = 0;
            }
            base.OnPointerClick(eventData);
        }

        
    }
}

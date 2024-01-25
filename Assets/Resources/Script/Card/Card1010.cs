using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//浴火重生			在本局剩余时间内，当你阵亡时，复活并永久减少10点生命上限，回复100%血量
public class Card1010 : CardItem
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

        if (TryUse() == true)
        {

            Debug.Log("1010");
            // 使用效果
            // 加buff
            BuffManager.Instance.AddBuff(GameManager.Instance.player.gameObject, 3004);
            

           
            base.OnPointerClick(eventData);
        }

        
    }
}

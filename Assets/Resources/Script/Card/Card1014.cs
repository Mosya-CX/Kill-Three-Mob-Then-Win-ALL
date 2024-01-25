using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//起草			造成6点木元素伤害，你的下个回合额外抽2张牌
public class Card1014 : CardItem
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
            Debug.Log("1014");

            //播放特效
            GameManager.Instance.player.animator.SetTrigger("Plant");

            // 使用效果
            GameManager.Instance.enemy.curHP -= 6;
            BuffManager.Instance.AddBuff(GameManager.Instance.enemy.gameObject, 3002);
            // 
            BuffManager.Instance.AddBuff(GameManager.Instance.player.gameObject, 3007);
            //抽卡效果
            //CardItem item = UIManager.Instance.GetUI<FightUI>("FightUI").CreateCardItem(2, true);

            base.OnPointerClick(eventData);
        }
        
    }
}

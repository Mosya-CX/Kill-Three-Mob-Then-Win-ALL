using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
//防御	增加4点护盾

public class Card1001 : CardItem
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
            //播放特效
            GameManager.Instance.player.animator.SetTrigger("Defend");

            //播放音效
            AudioManager.Instance.ArmorAudio();

            //效果
            GameManager.Instance.player.Shield += 4;

            base.OnPointerClick(eventData);
        }
        
    }
}

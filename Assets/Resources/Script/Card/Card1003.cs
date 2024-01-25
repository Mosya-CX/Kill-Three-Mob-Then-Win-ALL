using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

//快速防守	Card1003	获得12点格挡
public class Card1003 : CardItem
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

            // 音效
            AudioManager.Instance.ArmorAudio();
            // 效果
            GameManager.Instance.player.Shield += 12;

            base.OnPointerClick(eventData);
        }

   
    }

}

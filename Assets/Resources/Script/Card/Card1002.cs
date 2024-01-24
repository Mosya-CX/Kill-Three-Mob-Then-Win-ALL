using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//                 造成7伤害，摸一张
public class Card1002 : CardItem
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
            GameManager.Instance.player.animator.SetTrigger("Normal");
            // 
            AudioManager.Instance.AttackAudio();
            // 
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

            //
            UIManager.Instance.GetUI<FightUI>("FightUI").CreateCardItem(1, true);

            base.OnPointerClick(eventData);
        }


    }
}

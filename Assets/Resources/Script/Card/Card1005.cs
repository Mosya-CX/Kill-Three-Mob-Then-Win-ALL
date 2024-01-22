using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//���ؼ汸			���12���˺������12���
public class Card1005 : CardItem
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
            AudioManager.Instance.AttackAudio();
            // ʹ��Ч��
            GameManager.Instance.player.Shield += 12;
            if (GameManager.Instance.enemy.Shield >= 12)
            {
                GameManager.Instance.enemy.Shield -= 12;
            }
            else if (GameManager.Instance.enemy.Shield < 12 && GameManager.Instance.enemy.Shield > 0)
            {
                GameManager.Instance.enemy.curHP -= (12 - GameManager.Instance.enemy.Shield);
                GameManager.Instance.enemy.Shield = 0;
            }
            else
            {
                GameManager.Instance.enemy.curHP -= 12;
            }

            AudioManager.Instance.ArmorAudio();
            base.OnPointerClick(eventData);
        }
        
    }
}

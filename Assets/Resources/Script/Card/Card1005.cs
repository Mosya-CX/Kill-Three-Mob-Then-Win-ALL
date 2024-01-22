using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//���ؼ汸			���12���˺������12���
public class Card1005 : CardItem
{
    public override void OnPointerClick(PointerEventData eventData)
    {

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

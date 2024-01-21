using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

//打击			造成 5 点伤害
public class Card1000 : CardItem
{
    public override void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log(1);

        if (TryUse())
        {
            //播放特效

            //播放敌人受伤音效
            AudioManager.Instance.HurtEffectAudio();

            // 使用效果
            if (GameManager.Instance.enemy.Shield >= 5)
            {
                GameManager.Instance.enemy.Shield -= 5;
            }
            else if (GameManager.Instance.enemy.Shield < 5 && GameManager.Instance.enemy.Shield > 0)
            {
                GameManager.Instance.enemy.curHP -= (5 - GameManager.Instance.enemy.Shield);
                GameManager.Instance.enemy.Shield = 0;
            }
            else
            {
                GameManager.Instance.enemy.curHP -= 5;
            }


            base.OnPointerClick(eventData);
        }

    }
}

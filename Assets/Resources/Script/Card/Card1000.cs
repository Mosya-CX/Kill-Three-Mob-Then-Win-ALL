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
        //播放特效

        //播放敌人受伤音效
        AudioManager.Instance.EnemyHurtAudio();
        //敌人受伤
        //RoleBase hitEnemy=
        //hitEnemy.Hit(val);


        base.OnPointerClick(eventData);
    }
}

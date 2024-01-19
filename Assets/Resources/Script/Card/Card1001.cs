using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
//防御			增加4点护盾
public class Card1001 : CardItem
{
    public override void OnPointerClick(PointerEventData eventData)
    {
        if(TryUse() == true)
        {
            //播放声音
            AudioManager.Instance.ArmorAudio();

            //增加护盾
            FightManager.Instance.defenseCount += 4;

            //刷新防御文本
            //UIManager...
            
        }
    }
}

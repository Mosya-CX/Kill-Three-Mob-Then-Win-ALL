using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

//快速防守 获得12点格挡
public class Card1003 : CardItem
{
    public override void OnPointerClick(PointerEventData eventData)
    {
        if (TryUse())
        {
            // 使用效果
            GameManager.Instance.player.Shield += 12;

            base.OnPointerClick(eventData);
        }

   
    }

}

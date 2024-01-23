using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//����			���8�㻤�ܣ��ڱ���ʣ��ʱ���ڣ�ʹ�������ϴ��ڲ������ĵ�ˮԪ�ظ���
public class Card1013 : CardItem
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
           
            // ʹ��Ч��
            GameManager.Instance.player.Shield += 20;
            // ��buff
            //BuffManager.Instance.AddBuff(GameManager.Instance.enemy.gameObject, 3005);


            base.OnPointerClick(eventData);
        }
        
    }
}

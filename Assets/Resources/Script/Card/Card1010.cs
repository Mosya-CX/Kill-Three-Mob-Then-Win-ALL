using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//ԡ������			�ڱ���ʣ��ʱ���ڣ���������ʱ��������ü���10���������ޣ��ظ�100%Ѫ��
public class Card1010 : CardItem
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

        if (TryUse() == true)
        {

            Debug.Log("1010");
            // ʹ��Ч��
            // ��buff
            BuffManager.Instance.AddBuff(GameManager.Instance.player.gameObject, 3004);
            

           
            base.OnPointerClick(eventData);
        }

        
    }
}

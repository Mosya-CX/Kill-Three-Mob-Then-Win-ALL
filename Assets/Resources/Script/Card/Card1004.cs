using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//�������			��������
public class Card1004 : CardItem
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

        // ʹ��Ч��
        if (TryUse() == true)
        {

            //�鿨Ч��
            if (FightCardManager.instance.hasCard() == true)
            {
                UIManager.Instance.GetUI<FightUI>("FightUI").CreateCardItem(2, true);

            }

            base.OnPointerClick(eventData);
        }

        
    }
}

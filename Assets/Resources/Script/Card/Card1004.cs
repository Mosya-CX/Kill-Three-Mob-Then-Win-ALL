using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//�������			��������
public class Card1004 : CardItem
{
    public override void OnPointerClick(PointerEventData eventData)
    {
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//��û���			��3����,����һ�����
public class Card1006 : CardItem
{
    public override void OnPointerClick(PointerEventData eventData)
    {
        // ʹ��Ч��
        if (TryUse() == true)
        {


            //�鿨Ч��
            if (FightCardManager.instance.hasCard() == true)
            {
                CardItem item = UIManager.Instance.GetUI<FightUI>("FightUI").CreateCardItem(2, true);
                item.cost = 0;
            }
            base.OnPointerClick(eventData);
        }

        
    }
}

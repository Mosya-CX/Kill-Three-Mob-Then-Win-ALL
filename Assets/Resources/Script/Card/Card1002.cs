using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//Ѹ�ݹ���			��� 7���˺�����1����
public class Card1002 : CardItem
{
    public override void OnPointerClick(PointerEventData eventData)
    {
        if(TryUse()==true) 
        {




            //�鿨Ч��
            if(FightCardManager.instance.hasCard() == true) 
            {
                UIManager.Instance.GetUI<FightUI>("FightUI").CreateCardItem(1);

            }
        }
        base.OnPointerClick(eventData);
    }
}

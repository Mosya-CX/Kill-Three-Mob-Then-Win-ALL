using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//ԡ������			��������ʱ��������ü���10���������ޣ��ظ�100%Ѫ��,��һ����
public class Card1010 : CardItem
{
    public override void OnPointerClick(PointerEventData eventData)
    {
      
        
        if (TryUse() == true)
        {
            // ʹ��Ч��
            BuffManager.Instance.AddBuff(GameManager.Instance.player.gameObject, 3004);
            

            //�鿨Ч��
            if (FightCardManager.instance.hasCard() == true)
            {
                CardItem item = UIManager.Instance.GetUI<FightUI>("FightUI").CreateCardItem(2);
                item.cost = 0;
            }
            base.OnPointerClick(eventData);
        }

        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//���			���6��ľԪ���˺�������¸��غ϶����2����
public class Card1014 : CardItem
{

    public override void OnPointerClick(PointerEventData eventData)
    {

        if (TryUse())
        {
            // ʹ��Ч��
            GameManager.Instance.enemy.curHP -= 6;
            BuffManager.Instance.AddBuff(GameManager.Instance.enemy.gameObject, 3002);
            // �»غ϶����������
            //�鿨Ч��
            if (FightCardManager.instance.hasCard() == true)
            {
                CardItem item = UIManager.Instance.GetUI<FightUI>("FightUI").CreateCardItem(2, true);
            }

            base.OnPointerClick(eventData);
        }
        
    }
}

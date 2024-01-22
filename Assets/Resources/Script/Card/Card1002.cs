using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//Ѹ�ݹ���			��� 7���˺�����1����
public class Card1002 : CardItem
{
    public override void OnPointerClick(PointerEventData eventData)
    {
        if (TryUse())
        {
            //��Ч
            AudioManager.Instance.AttackAudio();
            // ʹ��Ч��
            if (GameManager.Instance.enemy.Shield >= 7)
            {
                GameManager.Instance.enemy.Shield -= 7;
            }
            else if (GameManager.Instance.enemy.Shield < 7 && GameManager.Instance.enemy.Shield > 0)
            {
                GameManager.Instance.enemy.curHP -= (7 - GameManager.Instance.enemy.Shield);
                GameManager.Instance.enemy.Shield = 0;
            }
            else
            {
                GameManager.Instance.enemy.curHP -= 7;
            }

            //�鿨Ч��
            if (FightCardManager.instance.hasCard() == true)
            {
                UIManager.Instance.GetUI<FightUI>("FightUI").CreateCardItem(1);

            }

            base.OnPointerClick(eventData);
        }


    }
}

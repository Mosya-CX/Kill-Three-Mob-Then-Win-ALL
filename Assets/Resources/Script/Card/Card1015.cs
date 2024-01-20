using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//��֮����			���10��ľ�����˺����»غ϶�����2����ò���2����
public class Card1015 : CardItem
{
    public override void OnPointerClick(PointerEventData eventData)
    {

        if (TryUse())
        {
            if(GameManager.Instance.enemy.Shield >= 10)
            {
                GameManager.Instance.enemy.Shield -= 10;
            }
            else if (GameManager.Instance.enemy.Shield < 10 && GameManager.Instance.enemy.Shield > 0)
            {
                GameManager.Instance.enemy.curHP -= (10 - GameManager.Instance.enemy.Shield);
                GameManager.Instance.enemy.Shield = 0;
            }
            else
            {
                GameManager.Instance.enemy.curHP -= 10;
            }

            BuffManager.Instance.AddBuff(GameManager.Instance.enemy.gameObject, 3002);
            // �»غ�������
            GameManager.Instance.player.currentFee += 2;
            //�鿨Ч��
            if (FightCardManager.instance.hasCard() == true)
            {
                CardItem item = UIManager.Instance.GetUI<FightUI>("FightUI").CreateCardItem(2);
            }

            base.OnPointerClick(eventData);
        }
        
    }
}

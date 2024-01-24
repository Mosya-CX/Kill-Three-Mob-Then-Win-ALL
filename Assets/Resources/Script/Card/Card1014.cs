using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//���			���6��ľԪ���˺�������¸��غ϶����2����
public class Card1014 : CardItem
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
            Debug.Log("1014");

            //������Ч
            GameManager.Instance.player.animator.SetTrigger("Plant");

            // ʹ��Ч��
            GameManager.Instance.enemy.curHP -= 6;
            BuffManager.Instance.AddBuff(GameManager.Instance.enemy.gameObject, 3002);
            // 
            BuffManager.Instance.AddBuff(GameManager.Instance.player.gameObject, 3007);
            //�鿨Ч��
            //CardItem item = UIManager.Instance.GetUI<FightUI>("FightUI").CreateCardItem(2, true);

            base.OnPointerClick(eventData);
        }
        
    }
}

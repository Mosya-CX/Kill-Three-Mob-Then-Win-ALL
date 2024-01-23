using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//��ȫ��Ҫ     ��������������������²�����6��
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

        // 
        if (TryUse() == true)
        {
            Debug.Log("手牌有"+PlayerInfoManager.Instance.handCards.Count+"张");
            if (PlayerInfoManager.Instance.handCards.Count <= 6)
            {
                Debug.Log("手牌有" + PlayerInfoManager.Instance.handCards.Count + "张");
                // 抽卡
                UIManager.Instance.GetUI<FightUI>("FightUI").CreateCardItem(6 - PlayerInfoManager.Instance.handCards.Count + 1, true);
            }

            base.OnPointerClick(eventData);
        }

        
    }
}

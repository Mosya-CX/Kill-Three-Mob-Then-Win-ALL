using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

//我没意见			抽3张牌,其中一张免费
public class Card1006 : CardItem
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

        // 使用效果
        if (TryUse() == true)
        {

            //抽卡效果
            CardItem item = UIManager.Instance.GetUI<FightUI>("FightUI").CreateCardItem(3, true);
            item.cost = 0;
            // 更新花费ui
            TMP_Text[] Texts = item.gameObject.GetComponentsInChildren<TMP_Text>();
            foreach (var text in Texts)
            {
                if (text.name == "Expand")
                {
                    text.text = item.cost.ToString();
                }
            }

            base.OnPointerClick(eventData);
        }

        
    }
}

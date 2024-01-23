using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

//我没意见	Card1006	抽三张牌并随机使你的一张手牌变成0费
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

        //使用
        if (TryUse() == true)
        {

            //抽卡
            CardItem item = UIManager.Instance.GetUI<FightUI>("FightUI").CreateCardItem(3, true);
            item.cost = 0;
            //改费用和费用ui
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

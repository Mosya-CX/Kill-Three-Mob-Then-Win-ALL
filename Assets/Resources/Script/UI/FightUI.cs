using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FightUI : BasePanel
{
    public TMP_Text cardNumTxt;//卡牌数量
    public TMP_Text usedCardNumTxt;//弃牌堆数量
    public List<CardItem> cardItemList;//存储卡牌
    public Button turnBtn;

    private void Start()
    {
        turnBtn.onClick.AddListener(() => ChangeTurn());
    }


    private void Update()
    {
        if (FightManager.Instance.fightUnit is Fight_PlayerTurn || FightManager.Instance.fightUnit is Fight_EnemyTurn)
        {

            UpdateCardNum();
            updateUsedCardNum();
        }
        
    }

    //更新卡堆数量
    public void UpdateCardNum()
    {

        cardNumTxt.text = FightCardManager.instance.availableCardList.Count.ToString();
    }

    //更新弃牌堆数量
    public void updateUsedCardNum()
    {

        usedCardNumTxt.text = FightCardManager.instance.usedCardList.Count.ToString();
    }

    //创建卡牌物体
    public CardItem CreateCardItem(int count)
    {
        //if (count > FightCardManager.instance.availableCardList.Count)
        //{
        //    count = FightCardManager.instance.availableCardList.Count;
        //}
        CardItem item = null;
        for (int i = 0; i < count; i++)
        {
           
            // 此处判断牌堆是否还有牌
            if (FightCardManager.instance.availableCardList.Count == 0)
            {
                // 如果没牌了，就将弃牌堆的牌重新洗会可用牌堆
                FightCardManager.instance.ResetUsedCard();
                if (FightCardManager.instance.availableCardList.Count == 0)
                {
                    Debug.Log("没牌了");
                    
                    return item;
                }
            }
            
            // 抽卡
            string cardId = FightCardManager.instance.DrawCard();
            Dictionary<string, string> cardData = GameConfigManager.Instance.getCardById(cardId);

            Debug.Log(cardId);
            // 生成卡牌物体
            GameObject obj = Instantiate(Resources.Load(cardData["PrefabPath"]), transform) as GameObject;
            
            obj.GetComponent<RectTransform>().anchoredPosition = new Vector2(80, 70);
            
            // 设手牌区UI为父对象
            obj.transform.SetParent(GameObject.FindWithTag("HandCard").transform, false);
            
            //var item = obj.AddComponent<CardItem>();

            // 给卡牌加上脚本
            item = obj.AddComponent(System.Type.GetType(cardData["Script"])) as CardItem;
            
            // 初始化卡牌数据
            item.Init(cardData);
          
            // 添加到手牌列表
            cardItemList.Add(item);
            PlayerInfoManager.Instance.handCards.Add(cardId);

        }

        // 返回抽到的最后一张牌
        if (item != null)
        {
            return item;
        }
        else 
        {
            return null; 
        }

    }

    //更新卡牌位置
    public void UpdateCardItemPos()
    {
        float offset = 800.0f / cardItemList.Count;
        Vector2 startPos = new Vector2(-cardItemList.Count / 2.0f * offset + offset * 0.5f, -700);

        for (int i = 0; i < cardItemList.Count; i++)
        {
            cardItemList[i].GetComponent<RectTransform>().DOAnchorPos(startPos, 0.5f);
            startPos.x = startPos.x + offset;
        }
    }

    //删除卡牌物体
    public void RemoveCard(CardItem item)
    {
        item.enabled = false;//禁用卡牌逻辑

        //添加到弃牌集合
        FightCardManager.instance.usedCardList.Add(item.data["Id"]);

        //更新使用后的卡牌数量
        usedCardNumTxt.text = FightCardManager.instance.usedCardList.Count.ToString();

        //从集合中删除
        cardItemList.Remove(item);

        //刷新卡牌
        //UpdateCardItemPos();

        //卡牌移到弃牌堆效果
        item.GetComponent<RectTransform>().DOAnchorPos(new Vector2(1000, -700), 0.25f);

        item.transform.DOScale(0, 0.25f);

        Destroy(item.gameObject, 1);
    }

    //删除所有卡牌
    public void RemoveAllCards()
    {
        for (int i = cardItemList.Count - 1; i >= 0; i--)
        {
            RemoveCard(cardItemList[i]);
        }
    }

    //切换回合
    private void ChangeTurn()
    {
        //只有玩家回合才能切换
        if(FightManager.Instance.fightUnit is Fight_PlayerTurn) 
        {
            FightManager.Instance.ChangeType(FightType.Enemy);

        }
    }
}

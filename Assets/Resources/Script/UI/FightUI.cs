using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class FightUI : BasePanel
{
    private Text cardNumTxt;//卡牌数量
    private Text usedCardNumTxt;//弃牌堆数量
    private Text feeTxt;//费用数值
    private Text hpTxt;//血量数值
    private Image hpImg;//血条
    private Text defenseTxt;//防御数值
    private List<CardItem> cardItemList;//存储卡牌物体的集合

    private void Awake()
    {
        cardItemList = new List<CardItem>();
        cardNumTxt = transform.Find("hasCard/icon/Text").GetComponent<Text>();
        usedCardNumTxt = transform.Find("noCard/icon/Text").GetComponent<Text>();
        feeTxt = transform.Find("mana/Text").GetComponent<Text>();
        hpTxt = transform.Find("hp/hpText").GetComponent<Text>();
        hpImg = transform.Find("hp/fill").GetComponent<Image>();
        defenseTxt = transform.Find("hp/fangyu/Text").GetComponent<Text>();

    }
    private void Start()
    {
        UpdateHp();
        UpdateFee();
        UpdateDefense();
        UpdateCardNum();
        updateUsedCardNum();
    }
    //更新血量显示
    public void UpdateHp()
    {
        hpTxt.text = FightManager.Instance.curHp + "/" + FightManager.Instance.maxHp;
        hpImg.fillAmount = (float)FightManager.Instance.curHp / (float)FightManager.Instance.maxHp;
    }

    //更新费用
    public void UpdateFee()
    {
        feeTxt.text = FightManager.Instance.curFee + "/" + FightManager.Instance.maxFee;
    }

    //更新防御值
    public void UpdateDefense()
    {
        defenseTxt.text = FightManager.Instance.defenseCount.ToString();
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
    public void CreateCardItem(int count)
    {
        //待改动
        if (count > FightCardManager.instance.availableCardList.Count)
        {
            count = FightCardManager.instance.availableCardList.Count;
        }
        for (int i = 0; i < count; i++)
        {
            GameObject obj = Instantiate(Resources.Load("UI/CardItem"), transform) as GameObject;
            obj.GetComponent<RectTransform>().anchoredPosition = new Vector2(-1000, -700);//位置待定

            string cardId = FightCardManager.instance.DrawCard();
            Dictionary<string, string> data = GameConfigManager.Instance.getCardById(cardId);
            CardItem item = obj.AddComponent(System.Type.GetType(data["Script"])) as CardItem;
            item.Init(data);
            cardItemList.Add(item);
        }
    }

    //更新卡牌位置
    public void UpdateCardItemPos()
    {
        float offset = 800.0f / cardItemList.Count;
        Vector2 startPos = new Vector2(-cardItemList.Count / 2.0f * offset + offset * 0.5f, -700);//位置待测试

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
        UpdateCardItemPos();

        //卡牌移到弃牌堆效果
        item.GetComponent<RectTransform>().DOAnchorPos(new Vector2(1000, -700), 0.25f);//位置待测试

        item.transform.DOScale(0, 0.25f);

        Destroy(item.gameObject, 1);
    }
}

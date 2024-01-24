using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FightUI : BasePanel
{
    public TMP_Text cardNumTxt;//��������
    public TMP_Text usedCardNumTxt;//���ƶ�����
    public List<CardItem> cardItemList;//�洢����
    public Button turnBtn;

    private void Start()
    {
        turnBtn.onClick.AddListener(() => ChangeTurn());
    }


    private void Update()
    {
        UpdateCardNum();
        updateUsedCardNum();

    }

    //���¿�������
    public void UpdateCardNum()
    {

        cardNumTxt.text = FightCardManager.instance.availableCardList.Count.ToString();
    }

    //�������ƶ�����
    public void updateUsedCardNum()
    {
        usedCardNumTxt.text = FightCardManager.instance.usedCardList.Count.ToString();
    }

    //������������
    public CardItem CreateCardItem(int count, bool isSlectable)
    {
        //if (count > FightCardManager.instance.availableCardList.Count)
        //{
        //    count = FightCardManager.instance.availableCardList.Count;
        //}
        CardItem item = null;
        for (int i = 0; i < count; i++)
        {
           
            // 
            if (FightCardManager.instance.availableCardList.Count == 0)
            {
                //
                FightCardManager.instance.ResetUsedCard();
                if (FightCardManager.instance.availableCardList.Count == 0)
                {
                    
                    return item;
                }
            }
            
            // 
            string cardId = FightCardManager.instance.DrawCard();
            Dictionary<string, string> cardData = GameConfigManager.Instance.getCardById(cardId);
            //print(cardId);
            //print(cardData["PrefabPath"]);
            // 
            GameObject obj = Instantiate(Resources.Load(cardData["PrefabPath"]), transform) as GameObject;
            obj.GetComponent<RectTransform>().anchoredPosition = new Vector2(80, 70);
            
            // 
            obj.transform.SetParent(GameObject.FindWithTag("HandCard").transform, false);
            
            //var item = obj.AddComponent<CardItem>();

            // 
            item = obj.AddComponent(System.Type.GetType(cardData["Script"])) as CardItem;
            
            // 
            item.Init(cardData);
            
            item.isSlectable = isSlectable;

            // 
            cardItemList.Add(item);
            PlayerInfoManager.Instance.handCards.Add(cardId);

        }

        // ���س鵽�����һ����
        if (item != null)
        {
            return item;
        }
        else 
        {
            return null; 
        }

    }

    //���¿���λ��
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

    //ɾ����������
    public void RemoveCard(CardItem item)
    {
        item.enabled = false;//

        //
        FightCardManager.instance.usedCardList.Add(item.data["Id"]);

        //
        usedCardNumTxt.text = FightCardManager.instance.usedCardList.Count.ToString();
       
        //
        cardItemList.Remove(item);
        //
        //UpdateCardItemPos();

        //
        item.GetComponent<RectTransform>().DOAnchorPos(new Vector2(1000, -700), 0.25f);
        item.transform.DOScale(0, 0.25f);

        Destroy(item.gameObject, 1);
    }

    //ɾ�����п���
    public void RemoveAllCards()
    {
        for (int i = cardItemList.Count - 1; i >= 0; i--)
        {
            RemoveCard(cardItemList[i]);
        }
    }

    //�л��غ�
    public void ChangeTurn()
    {
        //ֻ����һغϲ����л�
        if(FightManager.Instance.fightUnit is Fight_PlayerTurn) 
        {
            // 播放动画
            GameManager.Instance.player.animator.SetTrigger("Attack");

            //FightManager.Instance.ChangeType(FightType.Enemy);

        }
    }
}

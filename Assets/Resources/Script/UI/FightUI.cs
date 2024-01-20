using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class FightUI : BasePanel
{
    private Text cardNumTxt;//��������
    private Text usedCardNumTxt;//���ƶ�����
    private Text feeTxt;//������ֵ
    private Text hpTxt;//Ѫ����ֵ
    private Image hpImg;//Ѫ��
    private Text defenseTxt;//������ֵ
    private List<CardItem> cardItemList;//�洢��������ļ���

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
    //����Ѫ����ʾ
    public void UpdateHp()
    {
        hpTxt.text = FightManager.Instance.curHp + "/" + FightManager.Instance.maxHp;
        hpImg.fillAmount = (float)FightManager.Instance.curHp / (float)FightManager.Instance.maxHp;
    }

    //���·���
    public void UpdateFee()
    {
        feeTxt.text = FightManager.Instance.curFee + "/" + FightManager.Instance.maxFee;
    }

    //���·���ֵ
    public void UpdateDefense()
    {
        defenseTxt.text = FightManager.Instance.defenseCount.ToString();
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
    public void CreateCardItem(int count)
    {
        //���Ķ�
        if (count > FightCardManager.instance.availableCardList.Count)
        {
            count = FightCardManager.instance.availableCardList.Count;
        }
        for (int i = 0; i < count; i++)
        {
            GameObject obj = Instantiate(Resources.Load("UI/CardItem"), transform) as GameObject;
            obj.GetComponent<RectTransform>().anchoredPosition = new Vector2(-1000, -700);//λ�ô���

            string cardId = FightCardManager.instance.DrawCard();
            Dictionary<string, string> data = GameConfigManager.Instance.getCardById(cardId);
            CardItem item = obj.AddComponent(System.Type.GetType(data["Script"])) as CardItem;
            item.Init(data);
            cardItemList.Add(item);
        }
    }

    //���¿���λ��
    public void UpdateCardItemPos()
    {
        float offset = 800.0f / cardItemList.Count;
        Vector2 startPos = new Vector2(-cardItemList.Count / 2.0f * offset + offset * 0.5f, -700);//λ�ô�����

        for (int i = 0; i < cardItemList.Count; i++)
        {
            cardItemList[i].GetComponent<RectTransform>().DOAnchorPos(startPos, 0.5f);
            startPos.x = startPos.x + offset;
        }
    }

    //ɾ����������
    public void RemoveCard(CardItem item)
    {
        item.enabled = false;//���ÿ����߼�

        //��ӵ����Ƽ���
        FightCardManager.instance.usedCardList.Add(item.data["Id"]);

        //����ʹ�ú�Ŀ�������
        usedCardNumTxt.text = FightCardManager.instance.usedCardList.Count.ToString();

        //�Ӽ�����ɾ��
        cardItemList.Remove(item);

        //ˢ�¿���
        UpdateCardItemPos();

        //�����Ƶ����ƶ�Ч��
        item.GetComponent<RectTransform>().DOAnchorPos(new Vector2(1000, -700), 0.25f);//λ�ô�����

        item.transform.DOScale(0, 0.25f);

        Destroy(item.gameObject, 1);
    }
}

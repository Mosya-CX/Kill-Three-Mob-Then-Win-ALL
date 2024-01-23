using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//����ս����ʼ��
public class FightInit : FightUnit
{
    public override void Init()
    {

        //�л�BGM
        AudioManager.Instance.FightingAudio();

        //��ʼ��ս����ֵ
        FightManager.Instance.Init();

        // ��������
        int progress = GameManager.Instance.currentProgress;
        GameObject Bg = GameObject.Find("Background");
        if (progress == 1)
        {
            // ���ر���
            Sprite newBg = Resources.Load<Sprite>("Img/UI 2/Bg1");
            Bg.GetComponent<SpriteRenderer>().sprite = newBg;

            EnemyManager.Instance.LoadMob("2001");
        }
        else if (progress == 2)
        {
            // ���ر���
            Sprite newBg = Resources.Load<Sprite>("Img/UI 2/Bg2");
            Bg.GetComponent<SpriteRenderer>().sprite = newBg;

            EnemyManager.Instance.LoadMob("2002");
        }
        else if (progress == 3)
        {
            // ���ر���
            Sprite newBg = Resources.Load<Sprite>("Img/UI 2/Bg3");
            Bg.GetComponent<SpriteRenderer>().sprite = newBg;

            EnemyManager.Instance.LoadMob("2003");
        }
        else if (progress == 4)
        {
            EnemyManager.Instance.LoadMob("2004");
        }

        // �����ƶ�
        if (progress != 4)
        {
            FightCardManager.instance.ResetHandCard();
            FightCardManager.instance.ResetUsedCard();
            // ���¼����ù������ѿ�
            FightCardManager.instance.availableCardList.AddRange(FightCardManager.instance.threeFeeUsedCardList);
            FightCardManager.instance.threeFeeUsedCardList.Clear();
        }
        
        // ��ʾս������()
        // UIManager.Instance.OpenUI<FightUI>("FightUI");
        GameObject.FindWithTag("FightUI").SetActive(true);
        GameObject.FindWithTag("Player").SetActive(true) ;

        if (progress != 4)
        {
            // ������ҷ�������
            GameManager.Instance.player.totalFee = 4;

            // �������Ѫ��
            GameManager.Instance.player.curHP = GameManager.Instance.player.maxHP;

            // ������һ���ֵ
            GameManager.Instance.player.Shield = 0;
        }

        //�л�����һغ�
        FightManager.Instance.ChangeType(FightType.Player);

        // �����ƶѵ�UI��ʾ
        GameObject.FindWithTag("FightUI").GetComponent<FightUI>().UpdateCardNum();
        GameObject.FindWithTag("FightUI").GetComponent<FightUI>().updateUsedCardNum();


        GameManager.Instance.isFighting = true;
        if (progress != 4)
        {
            GameManager.Instance.turn = 0;
        }
       
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
    }
}

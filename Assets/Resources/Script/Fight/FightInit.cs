using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//卡牌战斗初始化
public class FightInit : FightUnit
{
    public override void Init()
    {

        //切换BGM
        AudioManager.Instance.FightingAudio();

        //初始化战斗数值
        FightManager.Instance.Init();

        // 敌人生成
        int progress = GameManager.Instance.currentProgress;
        GameObject Bg = GameObject.FindWithTag("Background");
        if (progress == 1)
        {
            // 加载背景
            Sprite newBg = Resources.Load<Sprite>("Img/UI 2/Bg1");
            if (Bg.GetComponent<SpriteRenderer>() == null)
            {
                Bg.AddComponent<SpriteRenderer>().sprite = newBg;
            }
            else
            {
                Bg.GetComponent<SpriteRenderer>().sprite = newBg;
            }

            EnemyManager.Instance.LoadMob("2001");
        }
        else if (progress == 2)
        {
            // 加载背景
            Sprite newBg = Resources.Load<Sprite>("Img/UI 2/Bg2");
            if (Bg.GetComponent<SpriteRenderer>() == null)
            {
                Bg.AddComponent<SpriteRenderer>().sprite = newBg;
            }
            else
            {
                Bg.GetComponent<SpriteRenderer>().sprite = newBg;
            }

            EnemyManager.Instance.LoadMob("2002");
        }
        else if (progress == 3)
        {
            // 加载背景
            Sprite newBg = Resources.Load<Sprite>("Img/UI 2/Bg3");
            if (Bg.GetComponent<SpriteRenderer>() == null)
            {
                Bg.AddComponent<SpriteRenderer>().sprite = newBg;
            }
            else
            {
                Bg.GetComponent<SpriteRenderer>().sprite = newBg;
            }

            EnemyManager.Instance.LoadMob("2003");
        }
        else if (progress == 4)
        {
            EnemyManager.Instance.LoadMob("2004");
        }

        // 重置牌堆
        if (progress != 4)
        {
            // 重置手牌
            UIManager.Instance.GetUI<FightUI>("FightUI").RemoveAllCards();
            GameObject.Find("UI/FightUI").GetComponent<FightUI>().cardItemList.Clear();
            FightCardManager.instance.ResetHandCard();
            // 重置弃牌堆
            FightCardManager.instance.ResetUsedCard();
            // 重新加入用过的三费卡
            FightCardManager.instance.availableCardList.AddRange(FightCardManager.instance.threeFeeUsedCardList);
            FightCardManager.instance.threeFeeUsedCardList.Clear();
        }



        // 显示战斗界面()
        // UIManager.Instance.OpenUI<FightUI>("FightUI");
        GameObject.FindWithTag("FightUI").SetActive(true);
        GameObject.FindWithTag("Player").SetActive(true) ;

        if (progress != 4)
        {
            // 重置玩家费用上限
            GameManager.Instance.player.totalFee = 4;

            // 重置玩家血量
            GameManager.Instance.player.curHP = GameManager.Instance.player.maxHP;

            // 重置玩家护盾值
            GameManager.Instance.player.Shield = 0;

            // 重置摸牌数
            GameManager.Instance.player.cardCount = 6;
        }

        //切换到玩家回合
        FightManager.Instance.ChangeType(FightType.Player);

        // 更新牌堆的UI显示
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

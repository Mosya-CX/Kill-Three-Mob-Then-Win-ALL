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

        // 敌人生成(检测GameManager的progress判断处于什么阶段，通过EnemyManager里的LoadMob传入id生成对应的敌人)
        int progress = GameManager.Instance.currentProgress;
        if (progress == 1)
        {
            EnemyManager.Instance.LoadMob("2001");
        }
        else if (progress == 2)
        {
            EnemyManager.Instance.LoadMob("2002");
        }
        else if (progress == 3)
        {
            EnemyManager.Instance.LoadMob("2003");
        }

        // 重置牌堆
        FightCardManager.instance.ResetHandCard();
        FightCardManager.instance.ResetUsedCard();

        // 显示战斗界面()
        // UIManager.Instance.OpenUI<FightUI>("FightUI");
        GameObject.FindWithTag("FightUI").SetActive(true);
        GameObject.FindWithTag("Player").SetActive(true) ;

        // 重置玩家费用上限
        GameManager.Instance.player.totalFee = 4;

        //切换到玩家回合
        FightManager.Instance.ChangeType(FightType.Player);

        // 更新牌堆的UI显示
        GameObject.FindWithTag("FightUI").GetComponent<FightUI>().UpdateCardNum();
        GameObject.FindWithTag("FightUI").GetComponent<FightUI>().UpdateCardNum();
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
    }
}

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

        // 初始化可用牌堆
        FightCardManager.instance.Init();

        // 显示战斗界面(不需要)
        // UIManager.Instance.OpenUI<FightUI>("FightUI");

        // 重置玩家费用上线
        GameManager.Instance.player.totalFee = 4;

        //切换到玩家回合
        FightManager.Instance.ChangeType(FightType.Player);
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
    }
}

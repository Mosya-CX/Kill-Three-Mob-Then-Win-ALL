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
        // 敌人生成(检测GameManager的progress判断处于什么阶段，通过EnemyManager里的LoadMob传入id生成对应的敌人)
        int progress = GameManager.Instance.currentProgress;
        if (progress == 1)
        {
            EnemyManager.Instance.LoadMob(1000);
        }
        else if (progress == 2)
        {
            EnemyManager.Instance.LoadMob(1001);
        }
        else if (progress == 3)
        {
            EnemyManager.Instance.LoadMob(1002);
        }

        // 初始化玩家手牌
        FightCardManager.instance.Init();
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
    }
}

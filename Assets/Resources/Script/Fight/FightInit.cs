using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//卡牌战斗初始化
public class FightInit : FightUnit
{
    public override void Init()
    {
        //切换BGM

        // 敌人生成(检测GameManager的progress判断处于什么阶段，通过EnemyManager里的LoadMob传入id生成对应的敌人)

    }

    public override void OnUpdate()
    {
        base.OnUpdate();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//胜利
public class Fight_Win : FightUnit
{
    public override void Init()
    {
        GameManager.Instance.isFighting = false;
        

        GameManager.Instance.currentProgress++;
        // 有剧情用None
        // FightManager.Instance.ChangeType(FightType.None);
        FightManager.Instance.ChangeType(FightType.Select);
    }

    public override void OnUpdate()
    {

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ʤ��
public class Fight_Win : FightUnit
{
    public override void Init()
    {
        GameManager.Instance.isFighting = false;
        

        GameManager.Instance.currentProgress++;
        // �о�����None
        // FightManager.Instance.ChangeType(FightType.None);
        FightManager.Instance.ChangeType(FightType.Select);
    }

    public override void OnUpdate()
    {

    }
}

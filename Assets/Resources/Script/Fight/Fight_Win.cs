using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Ê¤Àû
public class Fight_Win : FightUnit
{
    public override void Init()
    {
        GameManager.Instance.currentProgress++;

        // FightManager.Instance.ChangeType(FightType.None);
    }

    public override void OnUpdate()
    {

    }
}

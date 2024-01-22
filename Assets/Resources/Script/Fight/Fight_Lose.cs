using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Ê§°Ü
public class Fight_Lose : FightUnit
{
    public override void Init()
    {
        GameManager.Instance.isFighting = false;

    }

    public override void OnUpdate()
    {

    }
}

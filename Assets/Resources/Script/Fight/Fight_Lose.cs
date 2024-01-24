using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

// ß∞‹
public class Fight_Lose : FightUnit
{
    public override void Init()
    {
        GameManager.Instance.isFighting = false;
        // …æ≥˝µ–»À
        Destroy(GameManager.Instance.enemy.gameObject);
        // ÷ÿ÷√’Ω∂∑
        FightManager.Instance.ChangeType(FightType.Init);

    }

    public override void OnUpdate()
    {

    }
}

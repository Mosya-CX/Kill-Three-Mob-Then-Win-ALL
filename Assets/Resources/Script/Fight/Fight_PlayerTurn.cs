using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//玩家回合
public class Fight_PlayerTurn : FightUnit
{
    public override void Init()
    {
        // 初始化玩家费用
        GameManager.Instance.Player.GetComponent<Player>().currentFee = 4;
        // 抽卡后台逻辑

        
        // 此处写抽牌的UI逻辑

    }

    public override void OnUpdate()
    {
        
    }
}

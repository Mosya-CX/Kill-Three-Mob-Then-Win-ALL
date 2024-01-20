using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//玩家回合
public class Fight_PlayerTurn : FightUnit
{
    public override void Init()
    {
        Debug.Log("PlayerTime");
        UIManager.Instance.ShowTip("玩家回合", Color.green, delegate ()
        {
            //抽牌
            Debug.Log("抽牌");
        });
        // 初始化玩家费用
        GameManager.Instance.player.currentFee = 4;
        // 抽卡后台逻辑

        
        // 此处写抽牌的UI逻辑

    }

    public override void OnUpdate()
    {
        
    }
}

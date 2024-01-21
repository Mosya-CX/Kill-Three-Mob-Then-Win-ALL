using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//玩家回合
public class Fight_PlayerTurn : FightUnit
{

    public override void Init()
    {

        // 重置当前费用
        GameManager.Instance.player.currentFee = GameManager.Instance.player.totalFee;
        // 提示玩家回合
        UIManager.Instance.ShowTip("玩家回合", Color.green, delegate ()
        {
            
            Debug.Log("抽牌");
            
        });
        //抽牌
        UIManager.Instance.GetUI<FightUI>("FightUI").CreateCardItem(6);
    }

    public override void OnUpdate()
    {
        
    }
}

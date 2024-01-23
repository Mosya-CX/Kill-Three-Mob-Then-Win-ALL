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
        UIManager.Instance.GetUI<FightUI>("FightUI").CreateCardItem(GameManager.Instance.player.cardCount, true);
        // 萤草buff效果
        if (GameManager.Instance.player.buffList.Contains(3007))
        {
            UIManager.Instance.GetUI<FightUI>("FightUI").CreateCardItem(2, true);
            BuffManager.Instance.DelBuff(GameManager.Instance.player.gameObject, 3007);
        }
        // 解放buff效果
        if (GameManager.Instance.player.buffList.Contains(3008))
        {
            GameManager.Instance.player.currentFee += 2;
            BuffManager.Instance.DelBuff(GameManager.Instance.player.gameObject, 3008);
        }
    }

    public override void OnUpdate()
    {
        
    }

    public override void End()
    {

    }
}

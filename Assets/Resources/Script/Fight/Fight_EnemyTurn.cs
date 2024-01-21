using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//敌人回合
public class Fight_EnemyTurn : FightUnit
{

    public override void Init()
    {
        // 绑定当前战斗的敌人
        GameObject enemy = GameManager.Instance.enemy.gameObject;
        //删除玩家所有卡牌
        UIManager.Instance.GetUI<FightUI>("FightUI").RemoveAllCards();
        //敌人回合提示
        UIManager.Instance.ShowTip("敌人回合", Color.red, delegate ()
        {
            Debug.Log("敌人回合");
        });
        // 执行敌人ai逻辑
        if (enemy.GetComponent<Boss1AI>() != null )
        {
            enemy.GetComponent<Boss1AI>().Move();
        }
        else if (enemy.GetComponent<Boss2AI>() != null)
        {
            enemy.GetComponent<Boss2AI>().Move();
        }
        else if (enemy.GetComponent<Boss3AI>() != null)
        {
            enemy.GetComponent<Boss3AI>().Move();
        }

        //切换到玩家回合
        FightManager.Instance.ChangeType(FightType.Player);
    }

    public override void OnUpdate()
    {
        // 敌人行动
    }
}

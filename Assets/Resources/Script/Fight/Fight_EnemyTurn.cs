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
        FightCardManager.instance.usedCardList.AddRange(PlayerInfoManager.Instance.handCards);
        PlayerInfoManager.Instance.handCards.Clear();
        GameObject.Find("UI/FightUI").GetComponent<FightUI>().cardItemList.Clear();

        //敌人回合提示
        UIManager.Instance.ShowTip("敌人回合", Color.red, delegate ()
        {
            
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
        else if (enemy.GetComponent<Boss4AI>() != null)
        {
            enemy.GetComponent<Boss4AI>().Move();
        }
        //切换到玩家回合
        FightManager.Instance.ChangeType(FightType.Player);
    }

    public override void OnUpdate()
    {
        // 敌人行动
    }

    public override void End()
    {
        GameManager.Instance.turn++;
        // 火花buff效果
        if (GameManager.Instance.enemy.buffList.Contains(3003) )
        {
            GameManager.Instance.enemy.curHP -= 1;
            BuffManager.Instance.AddBuff(GameManager.Instance.enemy.gameObject, 3000);
            BuffManager.Instance.DelBuff(GameManager.Instance.enemy.gameObject, 3003);
        }
        // 水之屏障buff效果
        if (GameManager.Instance.enemy.buffList.Contains(3006))
        {
            GameManager.Instance.enemy.curHP -= 3;
            BuffManager.Instance.AddBuff(GameManager.Instance.enemy.gameObject, 3001);
            BuffManager.Instance.DelBuff(GameManager.Instance.enemy.gameObject, 3006);
        }
    }
}

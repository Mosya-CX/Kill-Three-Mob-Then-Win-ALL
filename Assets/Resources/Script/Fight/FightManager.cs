using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//战斗枚举
public enum FightType
{
    None,
    Init,
    Player,//玩家回合
    Enemy,//敌人回合
    Win,
    Lose
}

/// <summary>
/// 战斗管理器
/// </summary>
public class FightManager : MonoBehaviour
{
    public static FightManager Instance;

    public FightUnit fightUnit;//战斗单元

    //初始化
    public void Init()
    {
        
    }
    private void Awake()
    {
        Instance = this; 
    }

    //切换战斗类型
    public void ChangeType(FightType type)
    {
        switch (type) 
        {
            case FightType.None:
                break;
            case FightType.Init:
                fightUnit = new FightInit();
                break;
            case FightType.Player:
                // 判断上回合是否是敌人回合
                if (fightUnit is Fight_EnemyTurn)
                {
                    // 在此进行回合结算
                    fightUnit.End();
                }
                fightUnit = new Fight_PlayerTurn();
                break;
            case FightType.Enemy:
                // 判断
                if (fightUnit is Fight_PlayerTurn)
                {
                    // 在此进行回合结算
                    Debug.Log("回合结算");
                    fightUnit.End();
                }
                Debug.Log("切换回合");
                fightUnit = new Fight_EnemyTurn();
                break;
            case FightType.Win:
                fightUnit = new Fight_Win();
                break;
            case FightType.Lose:
                fightUnit = new Fight_Lose();
                break;
        }
        fightUnit.Init();//初始化
    }

    private void Update()
    {
        // 此处判断牌堆是否还有牌
        if (FightCardManager.instance.availableCardList.Count <= 0)
        {
            // 如果没牌了，就将弃牌堆的牌重新洗会可用牌堆
            FightCardManager.instance.ResetUsedCard();
        }
        // 此处添加每帧运行逻辑
        if (fightUnit != null) 
        {
            fightUnit.OnUpdate();
        }
    }
}

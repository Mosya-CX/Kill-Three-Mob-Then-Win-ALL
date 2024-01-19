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

    public int maxHp;   //最大血量
    public int curHp;   //当前血量

    public int maxFee;  //最大费用
    public int curFee;  //当前费用

    public int defenseCount;    //防御值/格挡值

    //初始化
    public void Init()
    {
        maxHp = 100;
        curHp = 100;
        maxFee = 4;
        curFee = 4;
        defenseCount = 0;
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
                fightUnit = new FightUnit();
                break;
            case FightType.Player:
                fightUnit = new Fight_PlayerTurn();
                break;
            case FightType.Enemy:
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
        if(fightUnit != null) 
        {
            fightUnit.OnUpdate();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ս��ö��
public enum FightType
{
    None,
    Init,
    Player,//��һغ�
    Enemy,//���˻غ�
    Win,
    Lose
}

/// <summary>
/// ս��������
/// </summary>
public class FightManager : MonoBehaviour
{
    public static FightManager Instance;

    public FightUnit fightUnit;//ս����Ԫ

    //��ʼ��
    public void Init()
    {
        
    }
    private void Awake()
    {
        Instance = this; 
    }

    //�л�ս������
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
        fightUnit.Init();//��ʼ��
    }

    private void Update()
    {
        if(fightUnit != null) 
        {
            fightUnit.OnUpdate();
        }
    }
}

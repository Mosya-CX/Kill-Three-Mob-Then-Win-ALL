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
                // �ж��ϻغ��Ƿ��ǵ��˻غ�
                if (fightUnit is Fight_EnemyTurn)
                {
                    // �ڴ˽��лغϽ���
                    fightUnit.End();
                }
                fightUnit = new Fight_PlayerTurn();
                break;
            case FightType.Enemy:
                // �ж�
                if (fightUnit is Fight_PlayerTurn)
                {
                    // �ڴ˽��лغϽ���
                    Debug.Log("�غϽ���");
                    fightUnit.End();
                }
                Debug.Log("�л��غ�");
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
        // �˴��ж��ƶ��Ƿ�����
        if (FightCardManager.instance.availableCardList.Count <= 0)
        {
            // ���û���ˣ��ͽ����ƶѵ�������ϴ������ƶ�
            FightCardManager.instance.ResetUsedCard();
        }
        // �˴����ÿ֡�����߼�
        if (fightUnit != null) 
        {
            fightUnit.OnUpdate();
        }
    }
}

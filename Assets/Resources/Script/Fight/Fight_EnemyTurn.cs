using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//���˻غ�
public class Fight_EnemyTurn : FightUnit
{

    public override void Init()
    {
        // �󶨵�ǰս���ĵ���
        GameObject enemy = GameManager.Instance.Enemy;

        // ִ�е���ai�߼�
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

        //�л�����һغ�
        FightManager.Instance.ChangeType(FightType.Player);
    }

    public override void OnUpdate()
    {
        // �����ж�
    }
}

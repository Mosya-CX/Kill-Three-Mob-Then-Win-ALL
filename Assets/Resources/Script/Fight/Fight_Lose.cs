using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

//ʧ��
public class Fight_Lose : FightUnit
{
    public override void Init()
    {
        GameManager.Instance.isFighting = false;
        // ɾ������
        Destroy(GameManager.Instance.enemy.gameObject);
        // ����ս��
        FightManager.Instance.ChangeType(FightType.Init);

    }

    public override void OnUpdate()
    {

    }
}

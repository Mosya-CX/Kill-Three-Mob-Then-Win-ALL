using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//��һغ�
public class Fight_PlayerTurn : FightUnit
{
    public override void Init()
    {
        // ��ʼ����ҷ���
        GameManager.Instance.Player.GetComponent<Player>().currentFee = 4;
        // �鿨��̨�߼�

        
        // �˴�д���Ƶ�UI�߼�

    }

    public override void OnUpdate()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//��һغ�
public class Fight_PlayerTurn : FightUnit
{
    public override void Init()
    {
        Debug.Log("PlayerTime");
        UIManager.Instance.ShowTip("��һغ�", Color.green, delegate ()
        {
            //����
            Debug.Log("����");
        });
        // ��ʼ����ҷ���
        GameManager.Instance.player.currentFee = 4;
        // �鿨��̨�߼�

        
        // �˴�д���Ƶ�UI�߼�

    }

    public override void OnUpdate()
    {
        
    }
}

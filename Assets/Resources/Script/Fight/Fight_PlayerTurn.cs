using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//��һغ�
public class Fight_PlayerTurn : FightUnit
{

    public override void Init()
    {
        Debug.Log("PlayerTime");

        // ���õ�ǰ����
        GameManager.Instance.player.currentFee = GameManager.Instance.player.totalFee;
        // ��ʾ��һغ�
        UIManager.Instance.ShowTip("��һغ�", Color.green, delegate ()
        {
            //����
            Debug.Log("����");
            UIManager.Instance.GetUI<FightUI>("FightUI").CreateCardItem(6);
        });


    }

    public override void OnUpdate()
    {
        
    }
}

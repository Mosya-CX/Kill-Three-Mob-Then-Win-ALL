using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//��һغ�
public class Fight_PlayerTurn : FightUnit
{

    public override void Init()
    {

        // ���õ�ǰ����
        GameManager.Instance.player.currentFee = GameManager.Instance.player.totalFee;

        //����
        UIManager.Instance.GetUI<FightUI>("FightUI").CreateCardItem(6);

        // ��ʾ��һغ�
        UIManager.Instance.ShowTip("��һغ�", Color.green, delegate ()
        {
            
        });
        
    }

    public override void OnUpdate()
    {
        
    }
}

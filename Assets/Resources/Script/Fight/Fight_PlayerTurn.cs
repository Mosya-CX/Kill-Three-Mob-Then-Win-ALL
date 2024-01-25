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
        // ��ʾ��һغ�
        UIManager.Instance.ShowTip("��һغ�", Color.green, delegate ()
        {
            Debug.Log("����");
        });
        //����
        UIManager.Instance.GetUI<FightUI>("FightUI").CreateCardItem(GameManager.Instance.player.cardCount, true);
        // ө��buffЧ��
        if (GameManager.Instance.player.buffList.Contains(3007))
        {
            UIManager.Instance.GetUI<FightUI>("FightUI").CreateCardItem(2, true);
            BuffManager.Instance.DelBuff(GameManager.Instance.player.gameObject, 3007);
        }
        // ���buffЧ��
        if (GameManager.Instance.player.buffList.Contains(3008))
        {
            GameManager.Instance.player.currentFee += 2;
            BuffManager.Instance.DelBuff(GameManager.Instance.player.gameObject, 3008);
        }
    }

    public override void OnUpdate()
    {
        
    }

    public override void End()
    {
        // ��buffЧ��
        if (GameManager.Instance.enemy.buffList.Contains(3003))
        {
            GameManager.Instance.enemy.curHP -= 1;
            BuffManager.Instance.AddBuff(GameManager.Instance.enemy.gameObject, 3000);
            BuffManager.Instance.DelBuff(GameManager.Instance.enemy.gameObject, 3003);
        }
        // ˮ֮����buffЧ��
        if (GameManager.Instance.enemy.buffList.Contains(3006))
        {
            GameManager.Instance.enemy.curHP -= 3;
            BuffManager.Instance.AddBuff(GameManager.Instance.enemy.gameObject, 3001);
            BuffManager.Instance.DelBuff(GameManager.Instance.enemy.gameObject, 3006);
        }
    }
}

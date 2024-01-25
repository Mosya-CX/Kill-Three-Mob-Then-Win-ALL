using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//���˻غ�
public class Fight_EnemyTurn : FightUnit
{

    public override void Init()
    {
        // �󶨵�ǰս���ĵ���
        GameObject enemy = GameManager.Instance.enemy.gameObject;
        //ɾ��������п���
        UIManager.Instance.GetUI<FightUI>("FightUI").RemoveAllCards();
        //FightCardManager.instance.usedCardList.AddRange(PlayerInfoManager.Instance.handCards);
        PlayerInfoManager.Instance.handCards.Clear();
        //GameObject.Find("UI/FightUI").GetComponent<FightUI>().cardItemList.Clear();

        //���˻غ���ʾ
        UIManager.Instance.ShowTip("���˻غ�", Color.red, delegate ()
        {
            
        });
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
        else if (enemy.GetComponent<Boss4AI>() != null)
        {
            enemy.GetComponent<Boss4AI>().Move();
        }
        //�л�����һغ�
        //FightManager.Instance.ChangeType(FightType.Player);
    }

    public override void OnUpdate()
    {
        // �����ж�
    }

    public override void End()
    {
        GameManager.Instance.turn++;
        
    }
}

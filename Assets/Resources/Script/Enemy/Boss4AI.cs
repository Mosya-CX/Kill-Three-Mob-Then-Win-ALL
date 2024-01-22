using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss4AI : MonoBehaviour
{
    // ������ʽ
    public int attackMode;
    // ����˳��
    public int attackOrder;
    // ����Ҷ���
    public Player player;
    // ��û���������
    public int baseDamage;
    public Enemy enemy;
    //BOSS����һ���غϹ���
    public int nextMove;

    void Start()
    {
        nextMove = Random.Range(1, 4);
        attackMode = 1;
        player = GameManager.Instance.player;
        baseDamage = gameObject.GetComponent<Enemy>().baseDamage;
        enemy = GetComponent<Enemy>();
    }

    // �����ж�
    public void Move()
    {
        switch(nextMove)
        {
            case 1:
                Action1();
                break;
            case 2:
                Action2();
                break;
            case 3:
                Action3();
                break;
        }
    }

    public void Action1()
    {
        //�Ӷ�
        enemy.Shield += 10;
        //��ϴ������Ҽ���
    }

    public void Action2()
    {
        if (player.Shield >= baseDamage)
        {
            player.Shield -= baseDamage;
        }
        else if (player.Shield < baseDamage && player.Shield > 0)
        {
            player.curHP -= (baseDamage - player.Shield);
            player.Shield = 0;
        }
        else
        {
            player.curHP -= baseDamage;
        }
    }


    public void Action3()
    {
        BuffManager.Instance.enemyBuffList.Clear();//�Ƴ�����BUFF
        if (player.Shield >= 8)
        {
            player.Shield -= 8;
        }   //���������˺�
        else if (player.Shield < 8 && player.Shield > 0)
        {
            player.curHP -= (8 - player.Shield);
            player.Shield = 0;
        }
        else
        {
            player.curHP -= 8;
        }

    }
}

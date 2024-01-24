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
    // ��ö�����
    public Animator animator;

    void Start()
    {
        nextMove = Random.Range(1, 4);
        attackMode = 1;
        player = GameManager.Instance.player;
        baseDamage = gameObject.GetComponent<Enemy>().baseDamage;
        enemy = GetComponent<Enemy>();
        animator = gameObject.GetComponent<Animator>();
    }

    // �����ж�
    public void Move()
    {
        switch(nextMove)
        {
            case 1:
                //animator.SetTrigger("Defend");

                Action1();
                break;
            case 2:
                //animator.SetTrigger("Attack");

                Action2();
                break;
            case 3:
                //animator.SetTrigger("Skill");

                Action3();
                break;
        }
        nextMove = Random.Range(1, 4);
    }

    public void Action1()
    {
        //�Ӷ�
        enemy.Shield += 10;
        //��ϴ������Ҽ���
        FightCardManager.instance.availableCardList.Add("1018");
        FightCardManager.instance.availableCardList.Add("1018");
    }

    public void Action2()
    {
        // ���ɹ�����Ч
        // enemy.AttackEffeck();

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

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
    //�ϻغ��Ƿ���Action3
    public bool isAction3;
    // ��ö�����
    public Animator animator;

    void Start()
    {
        nextMove = Random.Range(1, 4);
        attackMode = 1;
        player = GameManager.Instance.player;
        baseDamage = gameObject.GetComponent<Enemy>().baseDamage;
        enemy = GetComponent<Enemy>();
        switch (nextMove)
        {
            case 1:
                enemy.nextType = ActionType.Defend;
                break;
            case 2:
                enemy.nextType = ActionType.Attack;
                break;
            case 3:
                enemy.nextType = ActionType.Skill;
                break;
        }
        animator = gameObject.GetComponent<Animator>();

        nextMove = Random.Range(1, 4);
    }

    // �����ж�
    public void Move()
    {
        enemy.nextType = ActionType.Skill;
        switch (nextMove)
        {
            case 1:
                animator.SetTrigger("Defend");
                
                //Action1();
                break;
            case 2:
                animator.SetTrigger("Attack");
                
                //Action2();
                break;
            case 3:
                animator.SetTrigger("Skill");
           
                //Action3();
                isAction3 = true;
                break;
        }
        if (isAction3)
        {
            nextMove = Random.Range(1, 3);
            isAction3=false;
        }
        else
        {
            nextMove = Random.Range(1, 4);
        }
        switch (nextMove)
        {
            case 1:
                enemy.nextType = ActionType.Defend;
                break;
            case 2:
                enemy.nextType = ActionType.Attack;
                break;
            case 3:
                enemy.nextType = ActionType.Skill;
                break;
        }
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
        enemy.AttackEffeck();

        if (player.Shield >= baseDamage)
        {
            player.Shield -= baseDamage;
        }
        else if (player.Shield < baseDamage && player.Shield > 0)
        {
            player.curHP -= (baseDamage - player.Shield);
            player.Shield = 0;

            // �ظ�δ���񵲵�Ѫ��
            int addHp = baseDamage - player.Shield;
            if (enemy.curHP <= enemy.maxHP - addHp)
            {
                enemy.curHP += addHp;
            }
            else
            {
                enemy.curHP = enemy.maxHP;
            }
        }
        else
        {
            player.curHP -= baseDamage;
            // �ظ�δ���񵲵�Ѫ��
            int addHp = baseDamage;
            if (enemy.curHP <= enemy.maxHP - addHp)
            {
                enemy.curHP += addHp;
            }
            else
            {
                enemy.curHP = enemy.maxHP;
            }
        }
    }


    public void Action3()
    {
        // ���buff
        BuffManager.Instance.ClearBuff(gameObject);
        
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss3AI : MonoBehaviour
{
    // ������ʽ
    public int attackMode;
    // ����˳��
    public int attackOrder;
    // ����Ҷ���
    public Player player;
    // ��û���������
    public int baseDamage;
    //BOSS����һ���غϹ���
    public int nextMove;
    public Enemy enemy;
    
    void Start()
    {
        attackMode = 1;
        player = GameManager.Instance.player;
        baseDamage = gameObject.GetComponent<Enemy>().baseDamage;
        enemy = GetComponent<Enemy>();  
    }

    // �����ж�
    public void Move()
    {
        if (attackOrder == 1)
        {
            if (nextMove == 1)
            {
                Attack();
            }
            else
            {
                Defend();
            }
            attackOrder++;
        }
        if (attackOrder == 2)
        {
            if (nextMove == 1)
            {
                Attack();
            }
            else
            {
                Defend();
            }
            attackOrder++;
        }
        if (attackOrder == 3)
        {
            if (nextMove == 1)
            {
                Attack();
            }
            else
            {
                Defend();
            }
            enemy.nextType = ActionType.Skill;
            attackOrder++;

        }
        if (attackOrder == 4)
        {
            Skill();
            attackOrder = 1;
        }
        nextMove = Random.Range(1, 3);
        if (attackOrder != 4)
        {
            switch (nextMove)
            {
                case 1:
                    enemy.nextType = ActionType.Attack;
                    break;
                case 2:
                    enemy.nextType = ActionType.Defend;
                    break;
            }
        }
    }

   public void Attack()
    {
        int attackCount = 6;
        enemy.nextType = ActionType.Attack;
        while (attackCount > 0)
        {
            // ����Ч��

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
            attackCount--;
        }
    }

    public void Defend()
    {
        enemy.Shield += 3;
    }

    public void Skill()
    {
        if(enemy.maxHP/enemy.curHP>2 )
        {
            enemy.curHP = 0;
            player.totalFee -= 1;
        }
    }
}

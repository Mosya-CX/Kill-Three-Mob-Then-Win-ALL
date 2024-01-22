using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1AI : MonoBehaviour
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
        nextMove = Random.Range(1, 3);
        attackMode = 1;
        attackOrder = 1;
        player = GameManager.Instance.player.GetComponent<Player>();
        baseDamage = gameObject.GetComponent<Enemy>().baseDamage;
        enemy.GetComponent<Enemy>();
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
        else if (attackOrder == 2)
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
        else if (attackOrder == 3)
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
        if(attackOrder == 4)
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

    void Attack()
    {
        AudioManager.Instance.AttackAudio();
        AudioManager.Instance.HurtVoiceAudio();
        int attackCount = 5;
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

    void Defend()
    {
        // ����Ч��

        AudioManager.Instance.ArmorAudio();
        Debug.Log("���з���");
        gameObject.GetComponent<Enemy>().Shield += 12;
    }

    void Skill()
    {
        // ����Ч��
        baseDamage++;
    }
}

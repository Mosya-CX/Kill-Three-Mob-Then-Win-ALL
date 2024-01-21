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
    void Start()
    {
        attackMode = 1;
        player = GameManager.Instance.player;
        baseDamage = gameObject.GetComponent<Enemy>().baseDamage;
    }

    // �����ж�
    public void Move()
    {
        if(attackMode == 1) 
        {
            Attack();
            attackMode++;
        }

        if (attackMode == 2)
        {
            Defend();
            attackMode--;
        }

        if (attackOrder == 3)
        {
            Skill1();
        }
    }

    void Attack()
    {
        int attackCount = 3;
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
        //����
        gameObject.GetComponent<Enemy>().Shield += 12;
        baseDamage += 2;
    }

    void Skill1() 
    {
        //����

        gameObject.GetComponent<Enemy>().curHP = 0;


    }
}

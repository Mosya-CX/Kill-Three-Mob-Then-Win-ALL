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
    void Start()
    {
        attackMode = 1;
        attackMode = 1;
        player = GameManager.Instance.player;
        baseDamage = gameObject.GetComponent<Enemy>().baseDamage;
    }

    // �����ж�
    public void Move()
    {
        int tmp = Random.Range(1, 2);
        if (attackOrder == 1)
        {
            if (tmp == 1)
            {
                Debug.Log("׼������");
                Attack();
            }
            else
            {
                Debug.Log("׼������");
                Defend();
            }
            attackOrder++;
        }
        if (attackOrder == 2)
        {
            if (tmp == 1)
            {
                Debug.Log("׼������");
                Attack();
            }
            else
            {
                Debug.Log("׼������");
                Defend();
            }
            attackOrder++;
        }
        if (attackOrder == 3)
        {
            Skill1();
            attackOrder = 1;
        }
    }

    void Attack()
    {
        int attackCount = 5;
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
            Debug.Log("���й���");
            attackCount--;
        }
    }

    void Defend()
    {
        // ����Ч��

        Debug.Log("���з���");
        gameObject.GetComponent<Enemy>().Shield += 12;
    }

    void Skill1()
    {
        // ����Ч��

        baseDamage++;
    }
}

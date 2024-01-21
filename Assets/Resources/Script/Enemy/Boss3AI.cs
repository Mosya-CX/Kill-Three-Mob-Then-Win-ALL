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
        attackMode = 1;
        player = GameManager.Instance.Player.GetComponent<Player>();
        baseDamage = gameObject.GetComponent<Enemy>().baseDamage;
    }

    // �����ж�
    public void Move()
    {
        
    }

    public void Attack()
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

    public void Defend()
    {
        gameObject.GetComponent<Enemy>().Shield += 15;
        baseDamage += 2;
    }

    public void Skill()
    {

    }
}

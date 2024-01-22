using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2AI : MonoBehaviour
{

    // ������ʽ
    public int attackMode;
    // ����˳��
    public int attackOrder;
    // ����Ҷ���
    public Player player;
    // ��û���������
    public int baseDamage;
    //�ж��Ƿ�������
    public bool isCharging;
    //�����������˺�
    public int ChargingDamage;
    public Enemy enemy;
    void Start()
    {
        attackMode = 1;
        attackOrder = 5;
        isCharging = false;
        player = GameManager.Instance.player.GetComponent<Player>();
        baseDamage = gameObject.GetComponent<Enemy>().baseDamage;
        enemy = GetComponent<Enemy>();
        ChargingDamage = baseDamage / 3 * 7;
    }

    // �����ж�
    public void Move()
    {
        switch (attackOrder)
        {
            case 1:
                if (isCharging)
                {
                    ChargingAttack();
                    isCharging = false;
                    attackOrder = 2;
                }
                else
                {
                    isCharging = true;

                }
                break;
            case 2:
                if (isCharging)
                {
                    Recover();
                    isCharging = false;
                    attackOrder = 3;
                }
                else
                {
                    isCharging = true;
                }
                break;
            case 3:
                Attack();
                attackOrder = 1;
                break;
            
            case 5:
                Skill();
                attackOrder = 3;
                break;
        }
    }

    public void ChargingAttack()
    {
        if (player.Shield >= ChargingDamage)
        {
            player.Shield -= ChargingDamage;
        }
        else if (player.Shield < ChargingDamage && player.Shield > 0)
        {
            player.curHP -= (ChargingDamage - player.Shield);
            player.Shield = 0;
        }
        else
        {
            player.curHP -= ChargingDamage;
        }
    }

    public void Recover()
    {
        enemy.curHP += (int)((enemy.maxHP - enemy.curHP) * 0.3);
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

   

    public void Skill()//������ҳ�����
    {
        player.cardCount--;
    }

}

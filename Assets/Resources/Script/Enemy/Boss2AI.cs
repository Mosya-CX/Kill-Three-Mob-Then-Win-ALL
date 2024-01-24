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
    // �����������
    public Enemy enemy;
    // ��ö�����
    public Animator animator;
    void Start()
    {
        attackMode = 1;
        attackOrder = 5;
        isCharging = false;
        player = GameManager.Instance.player.GetComponent<Player>();
        baseDamage = gameObject.GetComponent<Enemy>().baseDamage;
        enemy = GetComponent<Enemy>();
        animator = gameObject.GetComponent<Animator>();
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
                    //animator.SetTrigger("ChargeAttack");

                    ChargingAttack();
                    isCharging = false;
                    attackOrder = 2;
                    enemy.nextType = ActionType.Skill;
                }
                else
                {
                    //animator.SetTrigger("Recover");

                    isCharging = true;
                    GameManager.Instance.player.totalFee--;
                    enemy.nextType = ActionType.Attack;
                }
                break;
            case 2:
                if (isCharging)
                {
                    //animator.SetTrigger("Recover");

                    Recover();
                    isCharging = false;
                    enemy.nextType = ActionType.Attack;
                    attackOrder = 3;
                }
                else
                {
                    //animator.SetTrigger("Charge");

                    isCharging = true;
                    GameManager.Instance.player.totalFee--;
                    enemy.nextType = ActionType.Attack;
                }
                break;
            case 3:
                //animator.SetTrigger("Attack");

                Attack();

                attackOrder = 1;
                enemy.nextType = ActionType.Skill;
                break;
            
            case 5:

                //animator.SetTrigger("Skill");
                
                Skill();

                attackOrder = 3;
                enemy.nextType = ActionType.Attack;
                break;
        }
    }

    public void ChargingAttack()
    {
        // ���ɹ�����Ч
        // enemy.AttackEffeck();

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

   

    public void Skill()//������ҳ�����
    {
        player.cardCount--;
    }

}

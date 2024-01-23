using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2AI : MonoBehaviour
{

    // 攻击方式
    public int attackMode;
    // 攻击顺序
    public int attackOrder;
    // 绑定玩家对象
    public Player player;
    // 获得基础攻击力
    public int baseDamage;
    //判断是否在蓄力
    public bool isCharging;
    //蓄力攻击的伤害
    public int ChargingDamage;
    // 获得自身数据
    public Enemy enemy;
    // 获得动画机
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

    // 敌人行动
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
                }
                else
                {
                    //animator.SetTrigger("Recover");

                    isCharging = true;

                }
                break;
            case 2:
                if (isCharging)
                {
                    //animator.SetTrigger("Recover");

                    Recover();
                    isCharging = false;
                    attackOrder = 3;
                }
                else
                {
                    //animator.SetTrigger("Charge");

                    isCharging = true;
                }
                break;
            case 3:
                //animator.SetTrigger("Attack");

                Attack();

                attackOrder = 1;
                break;
            
            case 5:

                //animator.SetTrigger("Skill");
                
                Skill();

                attackOrder = 3;
                break;
        }
    }

    public void ChargingAttack()
    {
        // 生成攻击特效
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
        // 生成攻击特效
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

   

    public void Skill()//减少玩家抽牌数
    {
        player.cardCount--;
    }

}

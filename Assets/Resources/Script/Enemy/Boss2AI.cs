using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2AI : MonoBehaviour
{




    // 攻击方式

    public int attackMode;
    //攻击顺序 
    public int attackOrder;
    // 帮绑定玩家物体
    public Player player;
    // 基础伤害
    public int baseDamage;
    //是否蓄力
    public bool isCharging;
    //蓄力伤害

    public int ChargingDamage;

    // 敌人物体
    public Enemy enemy;
    // 动画机
    public Animator animator;


    void Start()
    {
        attackMode = 1;
        attackOrder = 5;
        
        isCharging = false;
        player = GameManager.Instance.player.GetComponent<Player>();
        baseDamage = gameObject.GetComponent<Enemy>().baseDamage;
        enemy = GetComponent<Enemy>();

        enemy.nextType = ActionType.Skill;
        animator = gameObject.GetComponent<Animator>();

        ChargingDamage = baseDamage / 3 * 7;

        enemy.nextType = ActionType.Skill;
    }

    // �����ж�
    public void Move()
    {
        switch (attackOrder)
        {
            case 1:
                if (isCharging)
                {

                    animator.SetTrigger("ChargeAttack");

                    // ChargingAttack();

                    GameManager.Instance.player.totalFee++;
                   

                    isCharging = false;
                    attackOrder = 2;
                    enemy.nextType = ActionType.Skill;
                }
                else
                {
                    animator.SetTrigger("Charge");

                    isCharging = true;
                    //GameManager.Instance.player.totalFee--;
                    enemy.nextType = ActionType.Attack;
                }
                break;
            case 2:
                if (isCharging)
                {

                    animator.SetTrigger("Recover");
                    //Recover();
                    GameManager.Instance.player.totalFee++;
                    //Recover();
                    isCharging = false;
                    enemy.nextType = ActionType.Attack;
                    attackOrder = 3;
                }
                else
                {
                    animator.SetTrigger("Charge");

                    isCharging = true;
                    GameManager.Instance.player.totalFee--;

                    enemy.nextType = ActionType.Attack;

                    enemy.nextType = ActionType.Defend;

                }
                break;
            case 3:
                animator.SetTrigger("Attack");

                //Attack();

                attackOrder = 1;
                enemy.nextType = ActionType.Skill;
                break;
            
            case 5:

                animator.SetTrigger("Skill");
                
                //Skill();

                attackOrder = 3;
                enemy.nextType = ActionType.Attack;
                break;
        }
    }

    public void ChargingAttack()
    {
        // 
        enemy.AttackEffeck();

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
        // 
        enemy.AttackEffeck();

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

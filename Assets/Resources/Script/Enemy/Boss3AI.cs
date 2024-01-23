using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss3AI : MonoBehaviour
{
    // 攻击模式
    public int attackMode;
    // 攻击顺序
    public int attackOrder;
    // 绑定玩家
    public Player player;
    // 绑定伤害
    public int baseDamage;
    //BOSS下一步行动
    public int nextMove;
    public Enemy enemy;
    
    // 获得动画机
    public Animator animator;
    void Start()
    {
        attackMode = 1;
        player = GameManager.Instance.player;
        baseDamage = gameObject.GetComponent<Enemy>().baseDamage;
        enemy = gameObject.GetComponent<Enemy>();  
        animator = gameObject.GetComponent<Animator>();
    }

    // 行动
    public void Move()
    {
        if(gameObject.GetComponent<Enemy>().curHP <= 50)
        {
            attackMode = 3;
        }
        if(attackMode == 1) 
        {
            if (nextMove == 1)
            {
                //animator.SetTrigger("Attack");

                Attack();
            }
            else
            {
                //animator.SetTrigger("Defend");

                Defend();
            }
            attackOrder++;
        }

        else if (attackMode == 2)
        {
            if (nextMove == 1)
            {
                //animator.SetTrigger("Attack");

                Attack();
            }
            else
            {
                //animator.SetTrigger("Defend");

                Defend();
            }
            attackOrder++;
        }

        else if (attackOrder == 3)
        {
            if (nextMove == 1)
            {
                //animator.SetTrigger("Attack");

                Attack();
            }
            else
            {
                //animator.SetTrigger("Defend");

                Defend();
            }
            enemy.nextType = ActionType.Skill;
            attackOrder++;

        }
        if (attackOrder == 4)
        {
            animator.SetTrigger("Skill");

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
        // 生成攻击特效
        // enemy.AttackEffeck();

        AudioManager.Instance.AttackAudio();
        AudioManager.Instance.HurtVoiceAudio();
        int attackCount = 3;
        while (attackCount > 0)
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
            attackCount--;
        }
    }

    public void Defend()
    {
        AudioManager.Instance.ArmorAudio();
        //动画

        gameObject.GetComponent<Enemy>().Shield += 12;
        baseDamage += 2;
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

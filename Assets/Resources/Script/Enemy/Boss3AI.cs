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
    
    void Start()
    {
        nextMove = Random.Range(1, 3);
        if (nextMove == 1)
        {
            enemy.nextType = ActionType.Attack;
        }
        else if (nextMove == 2)
        {
            enemy.nextType = ActionType.Defend;
        }
        attackMode = 1;
        player = GameManager.Instance.player;
        baseDamage = gameObject.GetComponent<Enemy>().baseDamage;
        enemy = GetComponent<Enemy>();  
    }

    // 行动
    public void Move()
    {
        
        if(gameObject.GetComponent<Enemy>().curHP <= 50)
        {
            Skill();
        }
        else if(nextMove==1){
            Attack();
        }
        else if (nextMove == 2) 
        {
            Defend();
        }
        nextMove = Random.Range(1, 3);
        if (nextMove == 1)
        {
            enemy.nextType = ActionType.Attack;
        }
        else if (nextMove == 2)
        {
            enemy.nextType = ActionType.Defend;
        }
        

    }

   public void Attack()
    {
        AudioManager.Instance.AttackAudio();
        AudioManager.Instance.HurtVoiceAudio();
        int attackCount = 3;
        while (attackCount > 0)
        {
            // 动画

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

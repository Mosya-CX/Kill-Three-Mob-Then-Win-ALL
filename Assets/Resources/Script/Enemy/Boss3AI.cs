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
    public Animator animator;
    public Enemy enemy;
    
   
    void Start()
    {
        
        attackMode = 1;
        player = GameManager.Instance.player;
        baseDamage = gameObject.GetComponent<Enemy>().baseDamage;
        enemy = gameObject.GetComponent<Enemy>();  
        animator = gameObject.GetComponent<Animator>();


        nextMove = Random.Range(1, 3);
        attackMode = 1;
        player = GameManager.Instance.player;
        baseDamage = gameObject.GetComponent<Enemy>().baseDamage;
        enemy = gameObject.GetComponent<Enemy>();  
        animator = gameObject.GetComponent<Animator>();
        if (nextMove == 1)
        {
            enemy.nextType = ActionType.Attack;
        }
        else if (nextMove == 2)
        {
            enemy.nextType = ActionType.Defend;
        }
    }

    // 行动
    public void Move()
    {
        
        if(gameObject.GetComponent<Enemy>().curHP <= 50)
        {
            StartCoroutine(DelayExecution(1.5f, Skill));
            animator.SetTrigger("Skill");
            
            //Skill();
        }
        else if(nextMove==1)
        {
            animator.SetTrigger("Attack");
            
            //Attack();
        }
        else if (nextMove == 2) 
        {
            animator.SetTrigger("Defend");

            //Defend();
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
        // 生成攻击特效
        enemy.AttackEffeck();

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
        player.totalFee -= 1;
        enemy.curHP = 0;
        
        //if (enemy.maxHP/enemy.curHP>2 )
        //{
            
        //}
    }

    // 协程方法，用于延迟执行  
    public IEnumerator DelayExecution(float delay, System.Action callback)
    {
        // 等待指定的延迟时间  
        yield return new WaitForSeconds(delay);

        // 调用回调函数  
        callback?.Invoke();
    }

}

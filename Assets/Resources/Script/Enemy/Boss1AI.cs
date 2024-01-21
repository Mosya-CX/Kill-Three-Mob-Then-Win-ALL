using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1AI : MonoBehaviour
{
    // 攻击方式
    public int attackMode;
    // 攻击顺序
    public int attackOrder;
    // 绑定玩家对象
    public Player player;
    // 获得基础攻击力
    public int baseDamage;
    void Start()
    {
        attackMode = 1;
        attackMode = 1;
        player = GameManager.Instance.player;
        baseDamage = gameObject.GetComponent<Enemy>().baseDamage;
    }

    // 敌人行动
    public void Move()
    {
        int tmp = Random.Range(1, 2);
        if (attackOrder == 1)
        {
            if (tmp == 1)
            {
                Attack();
            }
            else
            {
                Defend();
            }
            attackOrder++;
        }
        if (attackOrder == 2)
        {
            if (tmp == 1)
            {
                Attack();
            }
            else
            {
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
            // 动画效果


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
        // 动画效果

        gameObject.GetComponent<Enemy>().Shield += 12;
    }

    void Skill1()
    {
        // 动画效果

        baseDamage++;
    }
}

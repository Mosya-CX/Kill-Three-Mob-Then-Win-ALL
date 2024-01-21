using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss3AI : MonoBehaviour
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
        player = GameManager.Instance.Player.GetComponent<Player>();
        baseDamage = gameObject.GetComponent<Enemy>().baseDamage;
    }

    // 敌人行动
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 挂敌人身上
public class Enemy : RoleBase
{
    public GameObject Player;
    public int baseDemage;
    public int finalDemage;// 存储造成的最终伤害
    private void Start()
    {
        Init();
        Player = GameManager.Instance.Player;
        //finalDemage = baseDemage;
    }

    private void Update()
    {
        onUpdate();
    }

    // 攻击
    public void Attack()
    {
        Player.GetComponent<Player>().HP -= finalDemage;
    }
    // 防御
    public void Defend(int shieldValue)
    {
        Shield += shieldValue;
    }
    // 特殊(没想好怎么写)
    public void Move()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 挂敌人身上
// 存储敌人信息
public class Enemy : RoleBase
{
    public GameObject Player;
    public int baseDemage;// Excel里没写手动我们调吧
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

    
}

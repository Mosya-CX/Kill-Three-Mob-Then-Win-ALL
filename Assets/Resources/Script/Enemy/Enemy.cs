using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 敌人行动类型
public enum ActionType
{
    None,
    Attack,
    Defend,
    Skill,
}

// 挂敌人身上
// 存储敌人信息
public class Enemy : RoleBase
{
    public int id;
    public GameObject Player;
    public ActionType nextType;// 下回合行动
    public GameObject nextAction;// 绑定敌人下回合行动显示ui
    public int baseDamage;
    //public int finalDemage;// 存储造成的最终伤害
    private void Start()
    {
        maxHP = int.Parse(GameConfigManager.Instance.getEnemyById(id.ToString())["HP"]);
        baseDamage = int.Parse(GameConfigManager.Instance.getEnemyById(id.ToString())["baseDamage"]);
        Init();
        Player = GameManager.Instance.Player;
        //finalDemage = baseDamage;
        nextType = ActionType.None;
        // 此处创建显示写敌人下回合行动的UI
    }

    private void Update()
    {

        onUpdate();
    }

    
}

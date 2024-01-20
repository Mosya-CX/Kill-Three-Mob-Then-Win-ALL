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

    }
}

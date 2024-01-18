using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

// 挂玩家身上
public class Player : RoleBase
{
    public int currentFee;
    public int totalFee = 4;
    public TMP_Text FeeText;// 绑定费用显示ui
    public GameObject Enemy;
    public int finalDemage;// 玩家造成的最终伤害值存储在这
    private void Start()
    {
        Init();
        Enemy = GameManager.Instance.Enemy;
    }

    private void Update()
    {
        onUpdate();
        FeeText.text = currentFee + "/" + totalFee;
    }

    // 以下写玩家的行动方法
    // 攻击
    public void Attack()
    {
        Enemy.GetComponent<Enemy>().HP -= finalDemage;
    }
    // 防御
    public void Defend(int shieldValue)
    {
        Shield += shieldValue;
    }
   
}

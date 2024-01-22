using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

// 挂玩家身上
// 存储玩家信息
public class Player : RoleBase
{
    public int currentFee;
    public int totalFee = 4;
    public TMP_Text FeeText;// 绑定费用显示ui
    public GameObject Enemy;
    public int cardCount=6;   //玩家每回合的摸牌数
    public int finalDemage;// 玩家造成的最终伤害值存储在这
    private void Start()
    {
        Init();
        
    }

    private void Update()
    {
        
        onUpdate();
        FeeText.text = currentFee + "/" + totalFee;
    }

    
   
}

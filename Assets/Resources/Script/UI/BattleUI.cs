using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BattleUI : MonoBehaviour
{
    private Text playerHPText;    //玩家血量显示
    private Image playerHealthImage;     //血条
    private Text playerShieldText;   //护盾值
    private Text cardCountText;   //现有手牌数量
    private Text usedCardCountText;    //弃牌堆数量
    private void Awake()
    {
        playerHealthImage = transform.Find("playerHP/playerHP_Image").GetComponent<Image>();
        playerHPText = transform.Find("playerHP/playerHPText").GetComponent<Text>();    
        playerShieldText = transform.Find("Shield/playerShieldText").GetComponent <Text>();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleUI : MonoBehaviour
{
    private Text playerHPText;    //玩家血量显示
    private Image playerHealthImage;     //血条
    private Text playerShieldText;   //护盾值
    private Text cardCountText;   //现有手牌数量
    private Text usedCardCountText;    //弃牌堆数量
    private RoleBase role;    
    private void Awake()
    {
        playerHealthImage = transform.Find("playerHP/playerHP_Image").GetComponent<Image>();
        playerHPText = transform.Find("playerHP/playerHPText").GetComponent<Text>();    
        playerShieldText = transform.Find("Shield/playerShieldText").GetComponent <Text>();
        role = GetComponent<RoleBase>();
    }

    //更新玩家血量显示
    public void UpdatePlayerHP()
    {
        playerHPText.text = role.HPSlider.value +"/"+ role.HP;
        playerHealthImage.transform.localScale =new Vector3( 4 * (role.HPSlider.value / role.HP), playerHealthImage.transform.localScale.y, playerHealthImage.transform.localScale.z);  
    }
}

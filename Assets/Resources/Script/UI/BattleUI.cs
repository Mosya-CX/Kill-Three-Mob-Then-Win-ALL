using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleUI : MonoBehaviour
{
    private Text playerHPText;    //���Ѫ����ʾ
    private Image playerHealthImage;     //Ѫ��
    private Text playerShieldText;   //����ֵ
    private Text cardCountText;   //������������
    private Text usedCardCountText;    //���ƶ�����
    private RoleBase role;    
    private void Awake()
    {
        playerHealthImage = transform.Find("playerHP/playerHP_Image").GetComponent<Image>();
        playerHPText = transform.Find("playerHP/playerHPText").GetComponent<Text>();    
        playerShieldText = transform.Find("Shield/playerShieldText").GetComponent <Text>();
        role = GetComponent<RoleBase>();
    }

    //�������Ѫ����ʾ
    public void UpdatePlayerHP()
    {
        playerHPText.text = role.HPSlider.value +"/"+ role.HP;
        playerHealthImage.transform.localScale =new Vector3( 4 * (role.HPSlider.value / role.HP), playerHealthImage.transform.localScale.y, playerHealthImage.transform.localScale.z);  
    }
}

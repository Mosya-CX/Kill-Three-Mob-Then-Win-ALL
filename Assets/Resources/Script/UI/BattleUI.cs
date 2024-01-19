using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BattleUI : MonoBehaviour
{
    private Text playerHPText;    //���Ѫ����ʾ
    private Image playerHealthImage;     //Ѫ��
    private Text playerShieldText;   //����ֵ
    private Text cardCountText;   //������������
    private Text usedCardCountText;    //���ƶ�����
    private void Awake()
    {
        playerHealthImage = transform.Find("playerHP/playerHP_Image").GetComponent<Image>();
        playerHPText = transform.Find("playerHP/playerHPText").GetComponent<Text>();    
        playerShieldText = transform.Find("Shield/playerShieldText").GetComponent <Text>();
    }
}

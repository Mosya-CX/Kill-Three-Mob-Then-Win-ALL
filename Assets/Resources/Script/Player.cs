using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

// ���������
// �洢�����Ϣ
public class Player : RoleBase
{
    public int currentFee;
    public int totalFee = 4;
    public TMP_Text FeeText;// �󶨷�����ʾui
    public GameObject Enemy;
    public int cardCount=6;   //���ÿ�غϵ�������
    public int finalDemage;// �����ɵ������˺�ֵ�洢����
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

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

// ���������
public class Player : RoleBase
{
    public int currentFee;
    public int totalFee = 4;
    public TMP_Text FeeText;// �󶨷�����ʾui
    public GameObject Enemy;
    public int finalDemage;// �����ɵ������˺�ֵ�洢����
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

    // ����д��ҵ��ж�����
    // ����
    public void Attack()
    {
        Enemy.GetComponent<Enemy>().HP -= finalDemage;
    }
    // ����
    public void Defend(int shieldValue)
    {
        Shield += shieldValue;
    }
   
}

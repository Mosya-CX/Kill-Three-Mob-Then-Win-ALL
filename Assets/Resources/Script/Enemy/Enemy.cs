using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �ҵ�������
public class Enemy : RoleBase
{
    public GameObject Player;
    public int baseDemage;
    public int finalDemage;// �洢��ɵ������˺�
    private void Start()
    {
        Init();
        Player = GameManager.Instance.Player;
        //finalDemage = baseDemage;
    }

    private void Update()
    {
        onUpdate();
    }

    // ����
    public void Attack()
    {
        Player.GetComponent<Player>().HP -= finalDemage;
    }
    // ����
    public void Defend(int shieldValue)
    {
        Shield += shieldValue;
    }
    // ����(û�����ôд)
    public void Move()
    {
        
    }
}

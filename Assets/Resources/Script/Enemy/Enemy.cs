using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �ҵ�������
// �洢������Ϣ
public class Enemy : RoleBase
{
    public GameObject Player;
    public int baseDemage;// Excel��ûд�ֶ����ǵ���
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

    
}

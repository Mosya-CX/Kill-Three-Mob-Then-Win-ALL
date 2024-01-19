using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �����ж�����
public enum ActionType
{
    None,
    Attack,
    Defend,
    Skill,
}

// �ҵ�������
// �洢������Ϣ
public class Enemy : RoleBase
{
    public int id;
    public GameObject Player;
    public ActionType nextType;// �»غ��ж�
    public GameObject nextAction;// �󶨵����»غ��ж���ʾui
    public int baseDamage;
    //public int finalDemage;// �洢��ɵ������˺�
    private void Start()
    {
        maxHP = int.Parse(GameConfigManager.Instance.getEnemyById(id.ToString())["HP"]);
        baseDamage = int.Parse(GameConfigManager.Instance.getEnemyById(id.ToString())["baseDamage"]);
        Init();
        Player = GameManager.Instance.Player;
        //finalDemage = baseDamage;
        nextType = ActionType.None;
        // �˴�������ʾд�����»غ��ж���UI
    }

    private void Update()
    {

        onUpdate();
    }

    
}

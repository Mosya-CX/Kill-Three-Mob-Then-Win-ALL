using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

//ʧ��
public class Fight_Lose : FightUnit
{
    public override void Init()
    {
        GameManager.Instance.isFighting = false;
        // ɾ������
        //Destroy(GameManager.Instance.enemy.gameObject);
        // ����ս��
        //FightManager.Instance.ChangeType(FightType.Init);

        // �л�bgm

        // ���������  
        Cursor.lockState = CursorLockMode.Locked;
        // ���������  
        Cursor.visible = false;

        // ��������
        GameObject.Find("UI").GetComponent<Animator>().SetTrigger("Lose");
    }

    public override void OnUpdate()
    {

    }
}

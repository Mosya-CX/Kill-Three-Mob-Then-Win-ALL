using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ʤ��
public class Fight_Win : FightUnit
{
    public override void Init()
    {
        GameManager.Instance.isFighting = false;

        // �л�bgm

        GameManager.Instance.currentProgress++;
        // �о�����None
        // FightManager.Instance.ChangeType(FightType.None);
        if (GameManager.Instance.currentProgress != 5)
        {
            FightManager.Instance.ChangeType(FightType.Select);
        }
        else 
        {
            // ���������  
            Cursor.lockState = CursorLockMode.Locked;
            // ���������  
            Cursor.visible = false;

            GameObject.Find("UI").GetComponent<Animator>().SetTrigger("Win");
        }
    }

    public override void OnUpdate()
    {

    }
}

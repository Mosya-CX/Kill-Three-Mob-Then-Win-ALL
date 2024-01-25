using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//胜利
public class Fight_Win : FightUnit
{
    public override void Init()
    {
        GameManager.Instance.isFighting = false;

        // 切换bgm

        GameManager.Instance.currentProgress++;
        // 有剧情用None
        // FightManager.Instance.ChangeType(FightType.None);
        if (GameManager.Instance.currentProgress != 5)
        {
            FightManager.Instance.ChangeType(FightType.Select);
        }
        else 
        {
            // 锁定鼠标光标  
            Cursor.lockState = CursorLockMode.Locked;
            // 隐藏鼠标光标  
            Cursor.visible = false;

            GameObject.Find("UI").GetComponent<Animator>().SetTrigger("Win");
        }
    }

    public override void OnUpdate()
    {

    }
}

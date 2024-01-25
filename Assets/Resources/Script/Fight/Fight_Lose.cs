using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

//失败
public class Fight_Lose : FightUnit
{
    public override void Init()
    {
        GameManager.Instance.isFighting = false;
        // 删除敌人
        //Destroy(GameManager.Instance.enemy.gameObject);
        // 重置战斗
        //FightManager.Instance.ChangeType(FightType.Init);

        // 切换bgm

        // 锁定鼠标光标  
        Cursor.lockState = CursorLockMode.Locked;
        // 隐藏鼠标光标  
        Cursor.visible = false;

        // 死亡界面
        GameObject.Find("UI").GetComponent<Animator>().SetTrigger("Lose");
    }

    public override void OnUpdate()
    {

    }
}

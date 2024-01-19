using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LoginUI : BasePanel
{
    private void Awake()
    {
        //开始游戏
        //Register("bg/startbin").onClick = onStartGameBin;
    }

    private void onStartGameBin(GameObject obj,PointerEventData data) 
    {
        //关闭开始界面
        Close();
        //战斗初始化
        FightManager.Instance.ChangeType(FightType.Init);
    }
}

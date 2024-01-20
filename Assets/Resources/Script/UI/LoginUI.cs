using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LoginUI : BasePanel
{
    public Button startBtn;
    private void Awake()
    {
        //开始游戏
        //Register("bg/startBin").onClick = onStartGameBin;
        startBtn.onClick.AddListener(onStartGameBin);
    }

    private void onStartGameBin() 
    {
        //战斗初始化
        FightManager.Instance.ChangeType(FightType.Init);
        //关闭页面
        Debug.Log("关闭页面");
        Destroy(gameObject);
    }
}

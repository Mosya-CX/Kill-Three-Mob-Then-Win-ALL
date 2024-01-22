using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LoginUI : BasePanel
{
    public Button startBtn;
    public Button quitBtn;
    private void Awake()
    {
        //开始游戏
        //Register("bg/startBin").onClick = onStartGameBin;

        startBtn.onClick.AddListener(()=>onStartGameBin());// 添加的方法要是公有的
        quitBtn.onClick.AddListener(() => onQuitGameBin());
    }

    public void onStartGameBin() 
    {
        // 给游戏进程+1
        GameManager.Instance.currentProgress++;
        //战斗初始化
        FightManager.Instance.ChangeType(FightType.Select);
        //关闭页面
        Destroy(gameObject);
    }
    public void onQuitGameBin()
    {
        Application.Quit();
    }
}

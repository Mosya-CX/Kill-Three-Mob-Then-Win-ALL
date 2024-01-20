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
        startBtn.onClick.AddListener(onStartGameBtn);
        quitBtn.onClick.AddListener(onQuitGameBtn);
    }
    //开始游戏
    private void onStartGameBtn() 
    {
        //战斗初始化
        FightManager.Instance.ChangeType(FightType.Init);
        //关闭页面
        Debug.Log("关闭页面");
        Destroy(gameObject);
    }
    //退出游戏
    private void onQuitGameBtn()
    {
        //打包后才会生效
        Application.Quit();
        //编辑器内可用下面这行
        //UnityEditor.EditorApplication.isPlaying =false;
    }
}

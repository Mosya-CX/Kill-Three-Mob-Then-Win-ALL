using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;
using UnityEngine.Rendering;

public class BaseBuff
{
    int id;
    string imgPath;
    string Des;
    int lastTime;
    //string Effect;//有没有特效待定
    private void Awake()
    {
        imgPath = GameConfigManager.Instance.getBuffById(id.ToString())["imgPath"];
        Des = GameConfigManager.Instance.getBuffById(id.ToString())["Des"];
    }

    private void Start()
    {
        
    }
    // 以下写将Img和Des加载到UI界面的函数
    public void Active()
    {

    }
}

using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;
using UnityEngine.Rendering;

public class BaseBuff
{
    public int id;
    string name;
    string imgPath;
    string Des;
    public int lastTime;
    string Effect;
    public BaseBuff(int Id, int lasttime) 
    {
        id = Id;
        lastTime = lasttime;
        name = GameConfigManager.Instance.getBuffById(id.ToString())["Name"];
        imgPath = GameConfigManager.Instance.getBuffById(id.ToString())["imgPath"];
        Des = GameConfigManager.Instance.getBuffById(id.ToString())["Des"];
    }
    
    public virtual void Fun(GameObject target)
    {
        // 此处写buff的效果
    }

    // 以下写将Img和Des加载到UI界面的函数
    public void Active(string tag)
    {
        if (tag == "Player")
        {

        }
        else if (tag == "Enemy")
        {

        }
    }
    // 销毁
    public void Destory(string tag)
    {
        if (tag == "Player")
        {

        }
        else if (tag == "Enemy")
        {

        }
    }
}

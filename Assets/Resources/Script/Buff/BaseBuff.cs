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
    //string Effect;//��û����Ч����
    private void Awake()
    {
        imgPath = GameConfigManager.Instance.getBuffById(id.ToString())["imgPath"];
        Des = GameConfigManager.Instance.getBuffById(id.ToString())["Des"];
    }

    private void Start()
    {
        
    }
    // ����д��Img��Des���ص�UI����ĺ���
    public void Active()
    {

    }
}

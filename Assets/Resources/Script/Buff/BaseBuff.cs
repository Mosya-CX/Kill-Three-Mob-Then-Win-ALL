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
    int lastTime;
    string Effect;
    private void Awake()
    {
        name = GameConfigManager.Instance.getBuffById(id.ToString())["Name"];
        imgPath = GameConfigManager.Instance.getBuffById(id.ToString())["imgPath"];
        Des = GameConfigManager.Instance.getBuffById(id.ToString())["Des"];
    }

    private void Start()
    {
        
    }

    public virtual void Fun(GameObject target)
    {
        // �˴�дbuff��Ч��
    }

    // ����д��Img��Des���ص�UI����ĺ���
    public void Active(string tag)
    {
        if (tag == "Player")
        {

        }
        else if (tag == "Enemy")
        {

        }
    }
    // ����
    public void DisActive(string tag)
    {
        if (tag == "Player")
        {

        }
        else if (tag == "Enemy")
        {

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class SelectTurn : FightUnit
{

    public override void Init()
    {
        // �л�bgm
        AudioManager.Instance.CloseBGM();

        // ��ѡ���
        GameObject obj = GameObject.Instantiate(Resources.Load("Prefab/UI/CardSelectUI"), GameObject.Find("UI").transform) as GameObject;
        obj.name = "CardSelectUI";
    }

    public override void OnUpdate()
    {
        
    }

    public override void End()
    {
        
    }
}

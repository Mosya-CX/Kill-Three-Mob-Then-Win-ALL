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
        //��ʼ��Ϸ
        //Register("bg/startBin").onClick = onStartGameBin;
        startBtn.onClick.AddListener(onStartGameBin);
    }

    private void onStartGameBin() 
    {
        //�ر�ҳ��
        Debug.Log("�ر�ҳ��");
        Destroy(gameObject);
        //ս����ʼ��
        //FightManager.Instance.ChangeType(FightType.Init);
    }
}

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
        //��ʼ��Ϸ
        //Register("bg/startBin").onClick = onStartGameBin;

        startBtn.onClick.AddListener(()=>onStartGameBin());// ��ӵķ���Ҫ�ǹ��е�
        quitBtn.onClick.AddListener(() => onQuitGameBin());
    }

    public void onStartGameBin() 
    {
        // ����Ϸ����+1
        GameManager.Instance.currentProgress++;
        //ս����ʼ��
        FightManager.Instance.ChangeType(FightType.Select);
        //�ر�ҳ��
        Destroy(gameObject);
    }
    public void onQuitGameBin()
    {
        Application.Quit();
    }
}

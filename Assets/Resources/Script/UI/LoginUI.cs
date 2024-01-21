using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LoginUI : BasePanel
{
    public Button startBtn;
    public Button quitBin;
    private void Awake()
    {
        //��ʼ��Ϸ
        //Register("bg/startBin").onClick = onStartGameBin;

        startBtn.onClick.AddListener(()=>onStartGameBin());// ��ӵķ���Ҫ�ǹ��е�
    }

    public void onStartGameBin() 
    {
        // ����Ϸ����+1
        GameManager.Instance.currentProgress++;
        //ս����ʼ��
        FightManager.Instance.ChangeType(FightType.Init);
        //�ر�ҳ��
        Debug.Log("�ر�ҳ��");
        Destroy(gameObject);
    }
}

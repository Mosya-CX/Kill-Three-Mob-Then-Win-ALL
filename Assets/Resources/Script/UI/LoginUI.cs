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
        startBtn.onClick.AddListener(onStartGameBtn);
        quitBtn.onClick.AddListener(onQuitGameBtn);
    }
    //��ʼ��Ϸ
    private void onStartGameBtn() 
    {
        //ս����ʼ��
        FightManager.Instance.ChangeType(FightType.Init);
        //�ر�ҳ��
        Debug.Log("�ر�ҳ��");
        Destroy(gameObject);
    }
    //�˳���Ϸ
    private void onQuitGameBtn()
    {
        //�����Ż���Ч
        Application.Quit();
        //�༭���ڿ�����������
        //UnityEditor.EditorApplication.isPlaying =false;
    }
}

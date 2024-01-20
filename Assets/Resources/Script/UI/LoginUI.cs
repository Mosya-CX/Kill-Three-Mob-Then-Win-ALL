using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LoginUI : BasePanel
{
    private void Awake()
    {
        //��ʼ��Ϸ
        Register("bg/startBin").onClick = onStartGameBin;
    }

    private void onStartGameBin(GameObject obj,PointerEventData data) 
    {
        //ս����ʼ��
        FightManager.Instance.ChangeType(FightType.Init);
        //�رտ�ʼ����
        Close();
    }
}

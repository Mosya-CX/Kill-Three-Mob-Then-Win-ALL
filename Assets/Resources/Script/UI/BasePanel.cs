using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class BasePanel : MonoBehaviour
{
    //��ʾ
    public virtual void Open()
    {
        gameObject.SetActive(true);
    }

    //����
    public virtual void Hide()
    {
        gameObject.SetActive(false);
    }

    //�ر�/�ݻ�
    public virtual void Close()
    {
        UIManager.Instance.CloseUI(gameObject.name);
    }

}


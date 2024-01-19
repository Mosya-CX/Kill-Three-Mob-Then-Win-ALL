using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class BasePanel : MonoBehaviour
{
    //ÏÔÊ¾
    public virtual void Open()
    {
        gameObject.SetActive(true);
    }

    //Òþ²Ø
    public virtual void Hide()
    {
        gameObject.SetActive(false);
    }

    //¹Ø±Õ/´Ý»Ù
    public virtual void Close()
    {
        UIManager.Instance.CloseUI(gameObject.name);
    }

}


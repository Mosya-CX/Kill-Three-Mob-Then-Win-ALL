using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
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

    //×¢²áÊÂ¼þ
    public UIEventTrigger Register(string name)
    {
        Transform tf = transform.Find(name);
        return UIEventTrigger.Get(tf.gameObject);
    }
}


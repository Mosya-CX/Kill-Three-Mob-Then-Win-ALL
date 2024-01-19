using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class BasePanel : MonoBehaviour
{
    bool isRemove = false;
    new string name;
    public virtual void Open()
    {
        gameObject.SetActive(true);
    }

    public virtual void Close()
    {
        isRemove = true;
        gameObject.SetActive(false);
        Destroy(gameObject);
    }

}


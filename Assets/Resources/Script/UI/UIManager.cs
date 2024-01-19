using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class UIManager
{
    private static UIManager _instance;
    private Transform uiRoot;

    private Dictionary<string, string> pathDict;
    //预制件缓存字典
    private Dictionary<string, GameObject> prefabDict;
    //已打开界面的缓存字典
    public Dictionary<string, BasePanel> panelDict;

    public static UIManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new UIManager();
            }
            return _instance;
        }
    }

    public Transform UIRoot
    {
        get
        {
            if(uiRoot==null)
            {
                uiRoot = GameObject.Find("Canvas").transform;
            }
            return uiRoot;
        }
    }

    private UIManager()
    {
        InitDicts();
    }

    private void InitDicts()
    {
        prefabDict = new Dictionary<string, GameObject>();  
        panelDict = new Dictionary<string, BasePanel>();   
        pathDict = new Dictionary<string, string>()
        {
            { UIConst.FightUI, "Menu/FightUI" },
        };
    }

    public BasePanel OpenPanel(string name)
    {
        BasePanel panel = null; 
        //检查是否已打开
        if(panelDict.TryGetValue(name,out panel))
        {
            Debug.LogError("假面已打开：" + name);
            return null;
        }
        //检查路径是否有配置
        string path = "";
        if(!pathDict.TryGetValue(name,out path))
        {
            Debug.Log("界面名称错误，或者未配置路径：" + name);
            return null;
        }

        GameObject panelPrefab = null;
        if(!prefabDict.TryGetValue(name,out panelPrefab))
        {
            string realPath = "Prefab/Panel/" + path;
            panelPrefab = Resources.Load<GameObject>(realPath) as GameObject;
            prefabDict.Add(name, panelPrefab);
        }

        //打开界面
        GameObject panelObject = GameObject.Instantiate(panelPrefab, UIRoot, false);
        panel = panelObject.GetComponent<BasePanel>();
        panelDict.Add(name, panel);
        return panel;


    }

    public bool ClosePanel(string name)
    {
        BasePanel panel = null;
        if (!panelDict.TryGetValue(name, out panel))
        {
            Debug.LogError("界面未打开: " + name);
            return false;
        }

        panel.ClosePanel();
        return true;
    }
}


public class UIConst
{
   // public const string MainMenuPanel = "MainMenuPanel";
    public const string FightUI = "FightUI";

}

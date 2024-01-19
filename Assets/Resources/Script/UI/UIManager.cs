using System.Collections;
using System.Collections.Generic;
using UnityEngine;



// UI按钮通过该UI管理器打开UI
public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public static UIManager instance
    {
        get
        {
            return Instance;
        }
    }
    public Transform uiCanvas;// ui画布挂在上面
    List<BasePanel> uiList;

    private void Awake()
    {
        Instance = this;
        uiList = new List<BasePanel>();
    }

    //显示
    public BasePanel OpenUI<T>(string uiName) where T : BasePanel
    {
        BasePanel panel = Find(uiName);
        if (panel != null)
        {
            panel.Open();
        }
        else
        {
            //如果为空
            GameObject obj = Instantiate(Resources.Load("Prefab/UI/"+uiName), uiCanvas) as GameObject;
            //改名字
            obj.name = uiName;
            //添加脚本
            panel = obj.AddComponent<T>();
            //添加到集合存储
            uiList.Add(panel);
        }
        return panel;
    }
    
    //隐藏
    public void HideUI(string uiName)
    {
        BasePanel panel = Find(uiName);
        if(panel != null)
        {
            panel.Hide();
        }
    }

    //关闭
    public void CloseUI(string uiName) 
    {
        BasePanel panel = Find(uiName);
        if (panel != null)
        {
            uiList.Remove(panel);
            Destroy(panel.gameObject);
        }
    }
    //关闭所有界面
    public void CloseAllUI()
    {
        for(int i = uiList.Count - 1; i >= 0; i--) 
        {
            Destroy(uiList[i].gameObject);
        }
        uiList.Clear();
    }

    //寻找
    public BasePanel Find(string uiName)
    {
        for (int i = 0; i < uiList.Count; i++)
        {
            if (uiList[i].name == uiName)
            {
                return uiList[i];
            }
        }
        return null;
    }

}


public class UIConst
{
    
    public const string BattleUI = "BattleUI";

}

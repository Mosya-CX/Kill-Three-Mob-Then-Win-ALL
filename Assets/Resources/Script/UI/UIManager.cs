using System.Collections;
using System.Collections.Generic;
using UnityEngine;



// UI按钮通过该UI管理器打开UI
public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public Transform uiCanvas;// ui画布挂在上面
    List<BasePanel> uiList;

    private void Awake()
    {
        Instance = this;
        uiList = new List<BasePanel>();
    }


    public void openUI(string uiName)
    {
        BasePanel panel = null;
        for (int i = 0; i < uiList.Count; i++)
        {
            if (uiList[i].name == uiName)
            {
                panel = uiList[i];
                break;
            }
        }
        if (panel != null)
        {
            panel.Open();
        }
        else
        {
            GameObject obj = Instantiate(Resources.Load("Prefab\\UI\\"+uiName), uiCanvas) as GameObject;
            obj.name = uiName;
            obj.SetActive(true);
            panel = obj.AddComponent<BasePanel>();
            uiList.Add(panel);
        }
    }

}


public class UIConst
{
  
    public const string BattleUI = "BattleUI";

}

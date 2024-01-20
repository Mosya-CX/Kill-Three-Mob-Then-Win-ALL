using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;


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
        if (panel == null)
        {
            //加载
            GameObject obj = Instantiate(Resources.Load("Prefab/UI/" + uiName), uiCanvas) as GameObject;

            obj.name = uiName;
            //添加对应的脚本
            //panel = obj.AddComponent<T>();
            //添加到集合中存储
            uiList.Add(panel);
        }
        else
        {
            //显示
            panel.Open();
        }
        return panel;
    }

    //隐藏
    public void HideUI(string uiName)
    {
        BasePanel panel = Find(uiName);
        if (panel != null)
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
        for (int i = uiList.Count - 1; i >= 0; i--)
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
    /*//创建敌人头部的行动坐标物体
    public GameObject CreatActionIcon()
    {
        GameObject obj = Instantiate(Resources.Load("Prefab/UI/actionIcon"), uiCanvas) as GameObject;
        obj.transform.SetAsFirstSibling();//设置在父级的第一位
        return obj;
    }
    //创建敌人底部的血量物体
    public GameObject CreateHpItem()
    {
        GameObject obj = Instantiate(Resources.Load("Prefab/UI/HpItem"), uiCanvas) as GameObject;
        obj.transform.SetAsFirstSibling();//设置在父级的第一位
        return obj;
    }*/

    //提示界面
    public void ShowTip(string msg, Color color, System.Action callback = null)
    {
        GameObject obj = Instantiate(Resources.Load("Prefab/UI/Tips"), uiCanvas) as GameObject;
        Text _text = obj.transform.Find("bg/Text").GetComponent<Text>();
        _text.color = color;
        _text.text = msg;
        Tween scale1 = obj.transform.Find("bg").DOScale(1, 0.2f);
        Tween scale2 = obj.transform.Find("bg").DOScale(0, 0.2f);

        Sequence seq = DOTween.Sequence();
        seq.Append(scale1);
        seq.AppendInterval(0.5f);
        seq.Append(scale2);
        seq.AppendCallback(delegate ()
        {
            if (callback != null)
            {
                callback();
            }
        });

        MonoBehaviour.Destroy(obj, 1);
    }

    //获得某个界面的脚本
    public T GetUI<T>(string uiName) where T : BasePanel
    {
        BasePanel ui = Find(uiName);
        if (ui != null)
        {
            return ui.GetComponent<T>();
        }

        // 补充
        ui = GameObject.Find("UI/" + uiName).GetComponent<T>();
        if (ui != null)
        {
            return ui.GetComponent<T>();
        }


        return null;
    }
}



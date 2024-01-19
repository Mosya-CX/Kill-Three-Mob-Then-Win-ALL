using System.Collections;
using System.Collections.Generic;
using UnityEngine;



// UI��ťͨ����UI��������UI
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
    public Transform uiCanvas;// ui������������
    List<BasePanel> uiList;

    private void Awake()
    {
        Instance = this;
        uiList = new List<BasePanel>();
    }

    //��ʾ
    public BasePanel OpenUI<T>(string uiName) where T : BasePanel
    {
        BasePanel panel = Find(uiName);
        if (panel != null)
        {
            panel.Open();
        }
        else
        {
            //���Ϊ��
            GameObject obj = Instantiate(Resources.Load("Prefab/UI/"+uiName), uiCanvas) as GameObject;
            //������
            obj.name = uiName;
            //��ӽű�
            panel = obj.AddComponent<T>();
            //��ӵ����ϴ洢
            uiList.Add(panel);
        }
        return panel;
    }
    
    //����
    public void HideUI(string uiName)
    {
        BasePanel panel = Find(uiName);
        if(panel != null)
        {
            panel.Hide();
        }
    }

    //�ر�
    public void CloseUI(string uiName) 
    {
        BasePanel panel = Find(uiName);
        if (panel != null)
        {
            uiList.Remove(panel);
            Destroy(panel.gameObject);
        }
    }
    //�ر����н���
    public void CloseAllUI()
    {
        for(int i = uiList.Count - 1; i >= 0; i--) 
        {
            Destroy(uiList[i].gameObject);
        }
        uiList.Clear();
    }

    //Ѱ��
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

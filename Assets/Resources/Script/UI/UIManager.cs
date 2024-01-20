using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;


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
        if (panel == null)
        {
            //����
            GameObject obj = Instantiate(Resources.Load("Prefab/UI/" + uiName), uiCanvas) as GameObject;

            obj.name = uiName;
            //��Ӷ�Ӧ�Ľű�
            //panel = obj.AddComponent<T>();
            //��ӵ������д洢
            uiList.Add(panel);
        }
        else
        {
            //��ʾ
            panel.Open();
        }
        return panel;
    }

    //����
    public void HideUI(string uiName)
    {
        BasePanel panel = Find(uiName);
        if (panel != null)
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
        for (int i = uiList.Count - 1; i >= 0; i--)
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
    /*//��������ͷ�����ж���������
    public GameObject CreatActionIcon()
    {
        GameObject obj = Instantiate(Resources.Load("Prefab/UI/actionIcon"), uiCanvas) as GameObject;
        obj.transform.SetAsFirstSibling();//�����ڸ����ĵ�һλ
        return obj;
    }
    //�������˵ײ���Ѫ������
    public GameObject CreateHpItem()
    {
        GameObject obj = Instantiate(Resources.Load("Prefab/UI/HpItem"), uiCanvas) as GameObject;
        obj.transform.SetAsFirstSibling();//�����ڸ����ĵ�һλ
        return obj;
    }*/

    //��ʾ����
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

    //���ĳ������Ľű�
    public T GetUI<T>(string uiName) where T : BasePanel
    {
        BasePanel ui = Find(uiName);
        if (ui != null)
        {
            return ui.GetComponent<T>();
        }

        // ����
        ui = GameObject.Find("UI/" + uiName).GetComponent<T>();
        if (ui != null)
        {
            return ui.GetComponent<T>();
        }


        return null;
    }
}



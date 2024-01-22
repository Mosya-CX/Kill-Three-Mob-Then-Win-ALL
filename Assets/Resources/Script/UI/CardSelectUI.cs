using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEditor.XR;
using UnityEngine;
using UnityEngine.UI;

public class CardSelectUI : BasePanel
{
    public int progress;
    public List<CardItem> CardList;
    public bool isReCreate;
    public GameObject SelectMenu;

    private void Start()
    {
        isReCreate = false;
        progress = 1;
    }

    void Update()
    {
        if (progress == 1 && !isReCreate)
        {
            OnReCreate();
        }
        else if (progress == 2 && !isReCreate)
        {
            OnReCreate();
        }
        else if (progress == 3 && !isReCreate)
        {
            OnReCreate();
        }
        else if (progress == 4)
        {
            // �л���ս��ģʽ
            FightManager.Instance.ChangeType(FightType.Init);
            // �رս���
            Destroy(gameObject);
        }
    }
    public void OnReCreate()
    {
        // ɾ�����п�������
        foreach (var cardItem in CardList)
        {
            Destroy(cardItem.gameObject);
        }
        CardList.Clear();
        // ��������
        CreatCardToSelect(1000, 1007);
        CreatCardToSelect(1008, 1010);
        CreatCardToSelect(1011, 1013);
        CreatCardToSelect(1014, 1016);
        isReCreate = true;
    }

    public void CreatCardToSelect(int minId, int maxId)
    {
        //�����ȡ
        Dictionary<string, string> cardData = GameConfigManager.Instance.getCardById(Random.Range(minId, maxId+1).ToString());

        Debug.Log(cardData["Id"]);
        
        //���ɶ���
        GameObject obj = GameObject.Instantiate(Resources.Load(cardData["PrefabPath"])) as GameObject;
        obj.GetComponent<RectTransform>().anchoredPosition = new Vector2(80, 70);
        // ��ѡ������UIΪ������
        obj.transform.SetParent(SelectMenu.transform, false);
        // �����Ƽ��Ͻű�
        CardItem item = obj.AddComponent(System.Type.GetType(cardData["Script"])) as CardItem;
        // ��ʼ����������
        item.Init(cardData);
        item.isSlectable = false;
        // �洢��CardList��
        CardList.Add(item);
    }

}

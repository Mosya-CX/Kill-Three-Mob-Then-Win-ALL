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
            // 切换到战斗模式
            FightManager.Instance.ChangeType(FightType.Init);
            // 关闭界面
            Destroy(gameObject);
        }
    }
    public void OnReCreate()
    {
        // 删除所有卡牌物体
        foreach (var cardItem in CardList)
        {
            Destroy(cardItem.gameObject);
        }
        CardList.Clear();
        // 重新生成
        CreatCardToSelect(1000, 1007);
        CreatCardToSelect(1008, 1010);
        CreatCardToSelect(1011, 1013);
        CreatCardToSelect(1014, 1016);
        isReCreate = true;
    }

    public void CreatCardToSelect(int minId, int maxId)
    {
        //随机抽取
        Dictionary<string, string> cardData = GameConfigManager.Instance.getCardById(Random.Range(minId, maxId+1).ToString());

        Debug.Log(cardData["Id"]);
        
        //生成对象
        GameObject obj = GameObject.Instantiate(Resources.Load(cardData["PrefabPath"])) as GameObject;
        obj.GetComponent<RectTransform>().anchoredPosition = new Vector2(80, 70);
        // 设选择区域UI为父对象
        obj.transform.SetParent(SelectMenu.transform, false);
        // 给卡牌加上脚本
        CardItem item = obj.AddComponent(System.Type.GetType(cardData["Script"])) as CardItem;
        // 初始化卡牌数据
        item.Init(cardData);
        item.isSlectable = false;
        // 存储在CardList中
        CardList.Add(item);
    }

}

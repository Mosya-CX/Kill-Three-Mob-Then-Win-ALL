using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;


public class CardItem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Dictionary<string, string> data; //卡牌信息

    //初始化
    public void Init(Dictionary<string, string> data)
    { 
        this.data = data; 
    }

    //鼠标进入
    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.DOScale(1.5f, 0.25f);
    }

    //鼠标离开
    public void OnPointerExit(PointerEventData eventData)
    {
        transform.DOScale(1f, 0.25f);
    }

    //尝试使用卡牌
    public virtual bool TryUse()
    {
        //卡牌需要的费用
        int cost = int.Parse(data["Expend"]);

        if(cost > FightManager.Instance.curFee)
        {
            //费用不足
            //是否加音效待定

            //提示
            //UIManager.Instance.ShowTip("费用不足",Color.red);

            return false;
        }
        else
        {
            //减少目前费用
            FightManager.Instance.curFee -= cost;
            //刷新费用文本
            //UIManager.Instance.GetUI<FightUI>("FightUI").UpdateFee();

            return true;
        }
    }
}

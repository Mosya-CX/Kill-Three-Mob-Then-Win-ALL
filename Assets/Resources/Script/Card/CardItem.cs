using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;


public class CardItem : MonoBehaviour, IPointerClickHandler
{
    public Dictionary<string, string> data; //卡牌信息

    //卡牌需要的费用
    public int cost;

    //初始化
    public void Init(Dictionary<string, string> data)
    {
        this.data = data;
        cost = int.Parse(data["Expend"]);
    }
    private int index;

    

    /*//鼠标进入
    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.DOScale(1.5f, 0.25f);
        index = transform.GetSiblingIndex();
        transform.SetAsLastSibling();
        Debug.Log("鼠标进入");
    }

    //鼠标离开
    public void OnPointerExit(PointerEventData eventData)
    {
        transform.DOScale(1f, 0.25f);
        transform.SetSiblingIndex(index);
        Debug.Log("鼠标离开");

    }*/
    // 鼠标点击
    public virtual void OnPointerClick(PointerEventData eventData)
    {


        //播放点击音效
        AudioManager.Instance.ClickCardAudio();

        // 断绝父子关系
        //gameObject.transform.SetParent(null, true);
        //gameObject.transform.SetParent(GameObject.Find("UI/FightUI/Button").transform, true);

        //// 删除动画

        // 删除卡牌
        PlayerInfoManager.Instance.handCards.Remove(data["Id"]);
        FightCardManager.instance.usedCardList.Add(data["Id"]);
        //Destroy(gameObject);

    }

    //尝试使用卡牌
    public virtual bool TryUse()
    {
        

        if(cost > GameManager.Instance.player.currentFee)
        {
            //费用不足
            //是否加音效待定

            //提示
            UIManager.Instance.ShowTip("费用不足",Color.red);

            return false;
        }
        else
        {
            //减少目前费用
            GameManager.Instance.player.currentFee -= cost;
            //使用后的卡牌删除
            UIManager.Instance.GetUI<FightUI>("FightUI").RemoveCard(this);
            
            return true;
        }
    }

    //生成卡牌使用后的特效
    public void PlayEffect(Vector3 pos)
    {
        GameObject effectObj = Instantiate(Resources.Load(data["Effects"])) as GameObject;
        effectObj.transform.position = pos;
        Destroy(effectObj,2);
    }
}

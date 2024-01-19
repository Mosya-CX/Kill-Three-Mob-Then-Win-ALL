using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CardItem : MonoBehaviour
{
    public Dictionary<string, string> data; //卡牌信息

    public void Init(Dictionary<string, string> data)
    { 
        this.data = data; 
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

            //刷新费用文本（UI）
            //UIManager.Instance.GetUI<FightUI>("FightUI").UpdateFee();

            //使用的卡牌删除
            //UIManager.Instance.GetUI<FightUI>("FightUI").Removecard(this);

            return true;
        }
    }

    //创建卡牌使用后的特效
    public void PlayEffect(Vector2 pos)
    {
        //gameObject effectObj = 
    }
}

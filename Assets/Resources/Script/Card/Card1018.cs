using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//咒术			抽到时对玩家造成3点伤害，并将此牌消耗
public class Card1018 : CardItem
{
    private void Start()
    {
        // 动画效果

        // 延迟执行
        StartCoroutine(DelayAction(4.0f));
        


        
    }

    IEnumerator DelayAction(float delayTime)
    {
        // 等待指定的时间  
        yield return new WaitForSeconds(delayTime);

        if (GameManager.Instance.player.Shield >= 3)
        {
            GameManager.Instance.player.Shield -= 3;
        }
        else if (GameManager.Instance.player.Shield < 3 && GameManager.Instance.player.Shield > 0)
        {
            GameManager.Instance.player.curHP -= (3 - GameManager.Instance.player.Shield);
            GameManager.Instance.player.Shield = 0;
        }
        else
        {
            GameManager.Instance.player.curHP -= 3;
        }

        // 断绝父子关系
        gameObject.transform.SetParent(null, true);
        gameObject.transform.SetParent(GameObject.Find("UI/FightUI/Button").transform, true);

        // 删除动画

        // 删除卡牌
        PlayerInfoManager.Instance.handCards.Remove(data["Id"]);

        Destroy(gameObject);
    }
}

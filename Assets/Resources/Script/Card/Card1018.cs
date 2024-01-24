using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//����			�鵽ʱ��������3���˺���������������
public class Card1018 : CardItem
{
    private void Start()
    {
        // ����Ч��

        // �ӳ�ִ��
        StartCoroutine(DelayAction(1.5f));
        


        
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        //base.OnPointerClick(eventData);
    }

    IEnumerator DelayAction(float delayTime)
    {
        // �ȴ�ָ����ʱ��  
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

        // �Ͼ����ӹ�ϵ
        gameObject.transform.SetParent(null, true);
        gameObject.transform.SetParent(GameObject.Find("UI/FightUI/Button").transform, true);

        // ɾ������

        // ɾ������
        PlayerInfoManager.Instance.handCards.Remove(data["Id"]);
        GameObject.Find("UI/FightUI").GetComponent<FightUI>().cardItemList.Remove(this);

        Destroy(gameObject);
    }
}

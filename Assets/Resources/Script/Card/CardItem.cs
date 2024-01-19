using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;


public class CardItem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Dictionary<string, string> data; //������Ϣ

    //��ʼ��
    public void Init(Dictionary<string, string> data)
    { 
        this.data = data; 
    }

    //������
    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.DOScale(1.5f, 0.25f);
    }

    //����뿪
    public void OnPointerExit(PointerEventData eventData)
    {
        transform.DOScale(1f, 0.25f);
    }

    //����ʹ�ÿ���
    public virtual bool TryUse()
    {
        //������Ҫ�ķ���
        int cost = int.Parse(data["Expend"]);

        if(cost > FightManager.Instance.curFee)
        {
            //���ò���
            //�Ƿ����Ч����

            //��ʾ
            //UIManager.Instance.ShowTip("���ò���",Color.red);

            return false;
        }
        else
        {
            //����Ŀǰ����
            FightManager.Instance.curFee -= cost;
            //ˢ�·����ı�
            //UIManager.Instance.GetUI<FightUI>("FightUI").UpdateFee();

            return true;
        }
    }
}

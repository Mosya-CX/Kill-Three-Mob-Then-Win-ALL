using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;


public class CardItem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler,IPointerClickHandler
{
    public Dictionary<string, string> data; //������Ϣ

    //������Ҫ�ķ���
    public int cost;

    //��ʼ��
    public void Init(Dictionary<string, string> data)
    {
        this.data = data;
        cost = int.Parse(data["Expend"]);
    }
    private int index;

    

    //������
    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.DOScale(1.5f, 0.25f);
        index = transform.GetSiblingIndex();
        transform.SetAsLastSibling();
    }

    //����뿪
    public void OnPointerExit(PointerEventData eventData)
    {
        transform.DOScale(1f, 0.25f);
        transform.SetSiblingIndex(index);

    }
    // �����
    public virtual void OnPointerClick(PointerEventData eventData)
    {


        //���ŵ����Ч
        AudioManager.Instance.ClickCardAudio();

        // �Ͼ����ӹ�ϵ
        gameObject.transform.SetParent(null, true);
        gameObject.transform.SetParent(GameObject.Find("UI/FightUI/Button").transform, true);

        // ɾ������

        // ɾ������
        PlayerInfoManager.Instance.handCards.Remove(data["Id"]);
        
        Destroy(gameObject);
    }

    //����ʹ�ÿ���
    public virtual bool TryUse()
    {
        

        if(cost > GameManager.Instance.player.currentFee)
        {
            //���ò���
            //�Ƿ����Ч����

            //��ʾ
            UIManager.Instance.ShowTip("���ò���",Color.red);

            return false;
        }
        else
        {
            //����Ŀǰ����
            GameManager.Instance.player.currentFee -= cost;
            //ʹ�ú�Ŀ���ɾ��
            UIManager.Instance.GetUI<FightUI>("FightUI").RemoveCard(this);

            return true;
        }
    }

    //���ɿ���ʹ�ú����Ч
    public void PlayEffect(Vector3 pos)
    {
        GameObject effectObj = Instantiate(Resources.Load(data["Effects"])) as GameObject;
        effectObj.transform.position = pos;
        Destroy(effectObj,2);
    }
}

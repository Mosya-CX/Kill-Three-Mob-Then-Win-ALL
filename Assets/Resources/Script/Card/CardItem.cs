using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CardItem : MonoBehaviour
{
    public Dictionary<string, string> data; //������Ϣ

    public void Init(Dictionary<string, string> data)
    { 
        this.data = data; 
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
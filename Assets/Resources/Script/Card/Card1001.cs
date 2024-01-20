using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
//����			����4�㻤��
public class Card1001 : CardItem
{
    public override void OnPointerClick(PointerEventData eventData)
    {
        //��������
        AudioManager.Instance.ArmorAudio();

        //���ӻ���
        FightManager.Instance.defenseCount += 4;

        //ˢ�·����ı�
        UIManager.Instance.GetUI<FightUI>("FightUI").UpdateDefense();
         
        
        base.OnPointerClick(eventData);
    }
}

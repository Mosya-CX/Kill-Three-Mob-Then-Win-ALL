using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
//����			����4�㻤��
public class Card1001 : CardItem
{
    public override void OnPointerClick(PointerEventData eventData)
    {
        if(TryUse() == true)
        {
            //��������
            AudioManager.Instance.ArmorAudio();

            //���ӻ���
            FightManager.Instance.defenseCount += 4;

            //ˢ�·����ı�
            //UIManager...
            
        }
    }
}

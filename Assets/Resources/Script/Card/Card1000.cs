using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

//���			��� 5 ���˺�
public class Card1000 : CardItem
{
    public override void OnPointerClick(PointerEventData eventData)
    {
        //������Ч

        //���ŵ���������Ч
        AudioManager.Instance.EnemyHurtAudio();
        //��������
        //RoleBase hitEnemy=
        //hitEnemy.Hit(val);


        base.OnPointerClick(eventData);
    }
}

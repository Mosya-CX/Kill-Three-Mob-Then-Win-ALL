using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using System.Reflection;
using TMPro;


// �����ж�����
public enum ActionType
{
    None,
    Attack,
    Defend,
    Skill,
}

// �ҵ�������
// �洢������Ϣ
public class Enemy : RoleBase
{
    public int id;
    public GameObject Player;
    public ActionType nextType;// �»غ��ж�
    public GameObject nextAction;// �󶨵����»غ��ж���ʾui
    public int baseDamage;
    //public int finalDemage;// �洢��ɵ������˺�
    private void Start()
    {
        // ���°�Ѫ��
        HPSlider = GameObject.Find("UI/FightUI/Middle/RightTop/EnemyHP").GetComponent<UnityEngine.UI.Slider>() ;
        // ��Ѫ���ı�
        HPText = GameObject.Find("UI/FightUI/Middle/RightTop/EnemyHP/HPText").GetComponent<TMP_Text>();
        // �󶨻���ֵ�ı�
        shieldText = GameObject.Find("UI/FightUI/Middle/RightTop/Shield/ShieldValue").GetComponent<TMP_Text>();
        // ���°��»غ��ж���ʾui
        nextAction = GameObject.Find("UI/FightUI/Top/EnemyAction");

        Init();
        Player = GameObject.FindWithTag("Player");
        //finalDemage = baseDamage;
        nextType = ActionType.None;
        nextAction = null;
    }

    private void Update()
    {
        onUpdate();
        // �˴�������ʾ�����»غ��ж���UI
        if (nextType == ActionType.None)
        {
            UnityEngine.UI.Image img = nextAction.GetComponent<UnityEngine.UI.Image>();
            img.sprite = null;
        }
        else if (nextType == ActionType.Attack)
        {
            Sprite newSprite = Resources.Load<Sprite>("Img/Item/Attack");
            UnityEngine.UI.Image img = nextAction.GetComponent<UnityEngine.UI.Image>();
            img.sprite = newSprite;
        }
        else if (nextType == ActionType.Defend)
        {
            Sprite newSprite = Resources.Load<Sprite>("Img/Item/Defend");
            UnityEngine.UI.Image img = nextAction.GetComponent<UnityEngine.UI.Image>();
            img.sprite = newSprite;
        }
        else if (nextType == ActionType.Skill)
        {
            Sprite newSprite = Resources.Load<Sprite>("Img/Item/Skill");
            UnityEngine.UI.Image img = nextAction.GetComponent<UnityEngine.UI.Image>();
            img.sprite = newSprite;
        }

        
    }

    
}

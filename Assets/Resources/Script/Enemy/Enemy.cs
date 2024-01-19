using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;

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
        maxHP = int.Parse(GameConfigManager.Instance.getEnemyById(id.ToString())["HP"]);
        baseDamage = int.Parse(GameConfigManager.Instance.getEnemyById(id.ToString())["baseDamage"]);
        // ���°�Ѫ��
        HPSlider = GameObject.Find("EnemyHp").GetComponent<UnityEngine.UI.Slider>() ;
        // ���°��»غ��ж���ʾui
        nextAction = GameObject.Find("nextAction");
        Init();
        Player = GameManager.Instance.Player;
        //finalDemage = baseDamage;
        nextType = ActionType.None;
        nextAction = null;
    }

    private void Update()
    {
        // �˴�������ʾ�����»غ��ж���UI
        if (nextType == ActionType.None)
        {
            Sprite newSprite = Resources.Load<Sprite>("Img/Item/None");
            SpriteRenderer spriteRenderer = nextAction.GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = newSprite;
        }
        else if (nextType == ActionType.Attack)
        {
            Sprite newSprite = Resources.Load<Sprite>("Img/Item/Attack");
            SpriteRenderer spriteRenderer = nextAction.GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = newSprite;
        }
        else if (nextType == ActionType.Defend)
        {
            Sprite newSprite = Resources.Load<Sprite>("Img/Item/Defend");
            SpriteRenderer spriteRenderer = nextAction.GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = newSprite;
        }
        else if (nextType == ActionType.Skill)
        {
            Sprite newSprite = Resources.Load<Sprite>("Img/Item/Skill");
            SpriteRenderer spriteRenderer = nextAction.GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = newSprite;
        }

        onUpdate();
    }

    
}

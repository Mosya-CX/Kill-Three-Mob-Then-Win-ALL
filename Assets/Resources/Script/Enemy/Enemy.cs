using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;

// 敌人行动类型
public enum ActionType
{
    None,
    Attack,
    Defend,
    Skill,
}

// 挂敌人身上
// 存储敌人信息
public class Enemy : RoleBase
{
    public int id;
    public GameObject Player;
    public ActionType nextType;// 下回合行动
    public GameObject nextAction;// 绑定敌人下回合行动显示ui
    public int baseDamage;
    //public int finalDemage;// 存储造成的最终伤害
    private void Start()
    {
        maxHP = int.Parse(GameConfigManager.Instance.getEnemyById(id.ToString())["HP"]);
        baseDamage = int.Parse(GameConfigManager.Instance.getEnemyById(id.ToString())["baseDamage"]);
        // 重新绑定血条
        HPSlider = GameObject.Find("EnemyHp").GetComponent<UnityEngine.UI.Slider>() ;
        // 重新绑定下回合行动显示ui
        nextAction = GameObject.Find("nextAction");
        Init();
        Player = GameManager.Instance.Player;
        //finalDemage = baseDamage;
        nextType = ActionType.None;
        nextAction = null;
    }

    private void Update()
    {
        // 此处更新显示敌人下回合行动的UI
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

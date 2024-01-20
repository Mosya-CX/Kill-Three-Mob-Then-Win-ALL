using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using System.Reflection;
using TMPro;


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
        // 重新绑定血条
        HPSlider = GameObject.Find("UI/FightUI/Middle/RightTop/EnemyHP").GetComponent<UnityEngine.UI.Slider>() ;
        // 绑定血条文本
        HPText = GameObject.Find("UI/FightUI/Middle/RightTop/EnemyHP/HPText").GetComponent<TMP_Text>();
        // 绑定护盾值文本
        shieldText = GameObject.Find("UI/FightUI/Middle/RightTop/Shield/ShieldValue").GetComponent<TMP_Text>();
        // 重新绑定下回合行动显示ui
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
        // 此处更新显示敌人下回合行动的UI
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

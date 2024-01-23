using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using System.Reflection;
using TMPro;


// 枚举行动类型
public enum ActionType
{
    None,
    Attack,
    Defend,
    Skill,
}

// 敌人管理器
public class Enemy : RoleBase
{
    public int id;
    public GameObject Player;
    public ActionType nextType;// 下一个行动
    public GameObject nextAction;// 绑定ui
    public int baseDamage;
    UnityEngine.UI.Image img;
    //public int finalDemage;
    private void Start()
    {

        // 绑定血条
        HPSlider = GameObject.Find("UI/FightUI/Middle/RightTop/EnemyHP").GetComponent<UnityEngine.UI.Slider>() ;
        // 绑定血条文本
        HPText = GameObject.Find("UI/FightUI/Middle/RightTop/EnemyHP/HPText").GetComponent<TMP_Text>();
        // 绑定护盾文本
        shieldText = GameObject.Find("UI/FightUI/Middle/RightTop/Shield/ShieldValue").GetComponent<TMP_Text>();
        // 绑定下一个行动ui
        nextAction = GameObject.Find("UI/FightUI/Top/EnemyAction");
        Init();
        Player = GameObject.FindWithTag("Player");
        //finalDemage = baseDamage;
        nextType = ActionType.None;
    }

    private void Update()
    {
        onUpdate();
        // �˴�������ʾ�����»غ��ж���UI
        /*if (nextType == ActionType.None)
        {
            img = nextAction.GetComponent<UnityEngine.UI.Image>();
            //UnityEngine.UIElements.Image img = nextAction.GetComponent<UnityEngine.UIElements.Image>();
            //img.sprite = null;
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
        }*/

        
    }

    // 攻击瞬间特效
    public void AttackEffeck()
    {
        GameObject.Instantiate(Resources.Load("Prefab/Item/AttackEffeck"));
    }
    // 切换敌人状态
    public void SwitchToPlayerTrun()
    {
        FightManager.Instance.ChangeType(FightType.Player);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RoleBase : MonoBehaviour
{
    public int HP;
    public Slider HPSlider;// 绑定HP的
    public int Shield;// 护盾值
    public TMP_Text shieldText;// 绑定护盾值的文本
    public List<BaseBuff> Buffs;
    Animator animator;
    protected void Init()
    {
        HPSlider.maxValue = HP;
        HPSlider.minValue = 0;
        Shield = 0;
        animator = GetComponent<Animator>();
    }

    protected void onUpdate()
    {
        if (HP != HPSlider.value)
        {
            if (HP > HPSlider.value)
            {
                HPSlider.value += Time.deltaTime;
            }
            else if (HP < HPSlider.value)
            {
                HPSlider.value -= Time.deltaTime;
            }
        }
        
        shieldText.text = Shield.ToString();
    }
}

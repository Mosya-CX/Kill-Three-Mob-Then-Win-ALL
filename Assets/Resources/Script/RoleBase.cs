using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Data;


public class RoleBase : MonoBehaviour
{
    public int curHP;
    public int maxHP;
    public Slider HPSlider;// ��HP��Slider
    public TMP_Text HPText;  // ��HP��Text
    public int Shield;// ����ֵ
    public TMP_Text shieldText;// �󶨻���ֵ���ı�
    Animator animator;
    public List<int> buffList;
    protected void Init()
    {
        curHP = maxHP;
        HPSlider.maxValue = maxHP;
        HPSlider.minValue = 0;
        Shield = 0;
        animator = GetComponent<Animator>();
    }

    protected void onUpdate()
    {
        // ����Ѫ���ͻ���ֵ
        if (curHP != HPSlider.value)
        {
            if (curHP > HPSlider.value)
            {
                HPSlider.value += Time.deltaTime;
            }
            else if (curHP < HPSlider.value)
            {
                HPSlider.value -= Time.deltaTime;
            }
        }
        shieldText.text = Shield.ToString();
        HPText.text = curHP + " / " + maxHP;
    }
}

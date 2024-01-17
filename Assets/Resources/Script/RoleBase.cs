using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RoleBase : MonoBehaviour
{
    public int HP;
    public Slider HPSlider;
    public int Shield;
    public TMP_Text shieldText;
    public List<BaseBuff> Buffs;
    Animator animator;
    protected void Init()
    {
        HPSlider.maxValue = HP;
        HPSlider.minValue = 0;
        shieldText.text = Shield.ToString();
        animator = GetComponent<Animator>();
    }

    protected void onUpdate()
    {
        HPSlider.value = HP;
        shieldText.text = Shield.ToString();
    }
}

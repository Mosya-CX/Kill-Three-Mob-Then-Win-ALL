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
    private void Start()
    {
        HPSlider.maxValue = HP;
        HPSlider.minValue = 0;
        shieldText.text = Shield.ToString();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        HPSlider.value = HP;
        shieldText.text = Shield.ToString();
    }
}

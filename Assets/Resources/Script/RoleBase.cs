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
    public Slider HPSlider;// 绑定HP的Slider
    public TMP_Text HPText;  // 绑定HP的Text
    public int Shield;// 护盾值
    public TMP_Text shieldText;// 绑定护盾值的文本
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
        // 更新血量和护盾值
        if (curHP != HPSlider.value)
        {
            // 此处是血条渐变
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

        if (curHP <= 0)
        {
            // 玩家死亡后触发的功能逻辑
            if (tag == "Player")
            {

            }
            else if (tag == "Enemy")
            {
                // 播放死亡死亡动画

                EnemyManager.Instance.RemoveEnemy();
                Destroy(gameObject);// 如有动画此处应有个延迟，延迟时间应略比动画时间长一点
            }
        }
    }

    //受击
    public void Hit(int val)
    {
        //先扣护盾
        if(Shield >= val) 
        {
            Shield -= val;

            //播放受击动画
            
            
        }
        else
        {
            val = val - Shield;
            Shield = 0;
            curHP -= val;
            //播放受伤动画


        }
    }
}

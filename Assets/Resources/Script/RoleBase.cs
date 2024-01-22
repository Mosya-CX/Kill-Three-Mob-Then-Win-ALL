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
        HPSlider.value = HPSlider.maxValue;
        Shield = 0;

        shieldText.text = Shield.ToString();
        HPText.text = curHP + " / " + maxHP;

        //animator = GetComponent<Animator>();
    }

    protected void onUpdate()
    {
        // ����Ѫ���ͻ���ֵ
        if (curHP != HPSlider.value)
        {
            
            // �˴���Ѫ������
            if (curHP > HPSlider.value)
            {
                HPSlider.value += Time.deltaTime ;
            }
            else if (curHP < HPSlider.value)
            {
                HPSlider.value -= Time.deltaTime ;
            }
        }
        shieldText.text = Shield.ToString();
        HPText.text = curHP + " / " + maxHP;

        if (curHP <= 0)
        {
            // ��������󴥷��Ĺ����߼�
            if (tag == "Player")
            {
                // ����Ƿ���ԡ������buff
                if (buffList.Contains(3004))
                {
                    maxHP -= 10;
                    curHP = maxHP;
                }
                else
                {
                    //����������Ч
                    AudioManager.Instance.PlayerDeathAudio();
                    //�л���ʧ��״̬
                    FightManager.Instance.ChangeType(FightType.Lose);
                }
            }
            else if (tag == "Enemy")
            {
                // ���ŵ�����������

                // �Ƴ�����
                GameManager.Instance.enemy = null;

                //�л���ʤ��״̬
                FightManager.Instance.ChangeType(FightType.Win);

                Destroy(gameObject);
            }
        }
    }

    //�ܻ�
    public void Hit(int val)
    {
        //�ȿۻ���
        if(Shield >= val) 
        {
            Shield -= val;

            //�����ܻ�����
            
            
        }
        else
        {
            val = val - Shield;
            Shield = 0;
            curHP -= val;
            //�������˶���


        }
    }
}

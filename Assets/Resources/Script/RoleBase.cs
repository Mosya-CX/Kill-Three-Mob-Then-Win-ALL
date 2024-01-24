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
    public Animator animator;// ��ȡ������
    public int lastHP;// Ѫ���䶯ǰ����һ��Ѫ��
    public int lastShield;// ����ֵ�䶯ǰ����һ�λ���ֵ

    public List<int> buffList;


    protected void Init()
    {
        curHP = maxHP;
        lastHP = curHP;
        HPSlider.maxValue = maxHP;
        HPSlider.minValue = 0;
        HPSlider.value = HPSlider.maxValue;
        Shield = 0;
        lastShield = Shield;

        shieldText.text = Shield.ToString();
        HPText.text = curHP + " / " + maxHP;

        animator = gameObject.GetComponent<Animator>();
    }

    protected void onUpdate()
    {
        //����Ѫ��Slider
        if (maxHP != HPSlider.maxValue)
        {
            HPSlider.maxValue = maxHP;
        }

        if (!GameManager.Instance.isFighting && lastHP != curHP || !GameManager.Instance.isFighting && lastShield != Shield)
        {
            lastHP = curHP;
            lastShield = Shield;
        }

        if (lastShield != Shield && GameManager.Instance.isFighting)
        {
            if (lastShield < Shield)
            {
                GameObject obj = GameObject.Instantiate(Resources.Load("Prefab/Item/DamageNum")) as GameObject;
                obj.transform.SetParent(GameObject.Find("UI").transform, false);
                if (gameObject.tag == "Player")
                {
                    obj.GetComponent<RectTransform>().anchoredPosition = new Vector2(Random.Range(-450, -150), Random.Range(300, 401));// ��ĳ���������������λ��
                }
                else if (gameObject.tag == "Enemy")
                {
                    obj.GetComponent<RectTransform>().anchoredPosition = new Vector2(Random.Range(150, 450), Random.Range(300, 401));
                }
                obj.GetComponent<TMP_Text>().text = "+" + (Shield - lastShield);
                obj.GetComponent<TMP_Text>().color = Color.blue;
                
            }
            else if (lastShield > Shield)
            {
                GameObject obj = GameObject.Instantiate(Resources.Load("Prefab/Item/DamageNum")) as GameObject;
                obj.transform.SetParent(GameObject.Find("UI").transform, false);
                if (gameObject.tag == "Player")
                {
                    obj.GetComponent<RectTransform>().anchoredPosition = new Vector2(Random.Range(-450, -150), Random.Range(300, 401));// ��ĳ���������������λ��
                }
                else if (gameObject.tag == "Enemy")
                {
                    obj.GetComponent<RectTransform>().anchoredPosition = new Vector2(Random.Range(150, 450), Random.Range(300, 401));
                }
                obj.GetComponent<TMP_Text>().text = (Shield - lastShield).ToString();
                obj.GetComponent<TMP_Text>().color = Color.white;
            }
            lastShield = Shield;
        }

        // ����Ѫ���ͻ���ֵ
        if (curHP != HPSlider.value)
        {
            
            // �˴���Ѫ������
            if (curHP > HPSlider.value)
            {
                
                HPSlider.value += Time.deltaTime * 30;
                if (curHP != lastHP && GameManager.Instance.isFighting)
                {
                    // ���ɻظ���������
                    CreateRecoverNum();

                    lastHP = curHP;
                }
            }
            else if (curHP < HPSlider.value)
            {
                if (curHP != lastHP && GameManager.Instance.isFighting)
                {
                    // �����˺��������� 
                    CreateDamageNum();

                    lastHP = curHP;
                }

                HPSlider.value -= Time.deltaTime * 30;
            }

            if(HPSlider.value<=curHP+ Time.deltaTime * 30&& HPSlider.value>=curHP- Time.deltaTime * 30)
            {
                HPSlider.value=curHP;
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
                //����̰������Ч��
                if(name == "̰")
                {
                    FightCardManager.instance.availableCardList.Add("1017");
                    //Debug.Log("̰�ģ�");
                }
                //��������Ч������Ч������
                else if (name== "��")
                {
                    bool isCharging = GetComponent<Boss2AI>().isCharging;
                    if (isCharging)
                    {
                        GameManager.Instance.player.totalFee++;
                    }
                }
                // ���ŵ�����������

                // �Ƴ�����
                GameManager.Instance.enemy = null;

                //�л���ʤ��״̬
                FightManager.Instance.ChangeType(FightType.Win);

                Destroy(gameObject);
            }
        }
    }

    public void CreateRecoverNum()
    {
        // ���ɻ�Ѫ�������� 
        GameObject obj = GameObject.Instantiate(Resources.Load("Prefab/Item/DamageNum")) as GameObject;
        obj.transform.SetParent(GameObject.Find("UI").transform, false);
        if (gameObject.tag == "Player")
        {
            obj.GetComponent<RectTransform>().anchoredPosition = new Vector2(Random.Range(-450, -150), Random.Range(300, 401));// ��ĳ���������������λ��
        }
        else if (gameObject.tag == "Enemy")
        {
            obj.GetComponent<RectTransform>().anchoredPosition = new Vector2(Random.Range(150, 450), Random.Range(300, 401));
        }
        obj.GetComponent<TMP_Text>().text = "+" + (curHP - lastHP);
        obj.GetComponent<TMP_Text>().color = Color.green;
    }

    public void CreateDamageNum()
    {
        GameObject obj = GameObject.Instantiate(Resources.Load("Prefab/Item/DamageNum")) as GameObject;
        obj.transform.SetParent(GameObject.Find("UI").transform, false);
        if (gameObject.tag == "Player")
        {
            obj.GetComponent<RectTransform>().anchoredPosition = new Vector2(Random.Range(-450, -150), Random.Range(300, 401));// ��ĳ���������������λ��
        }
        else if (gameObject.tag == "Enemy")
        {
            obj.GetComponent<RectTransform>().anchoredPosition = new Vector2(Random.Range(150, 450), Random.Range(300, 401));
        }
        obj.GetComponent<TMP_Text>().text = (curHP - lastHP).ToString();
        obj.GetComponent<TMP_Text>().color = Color.red;
        
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

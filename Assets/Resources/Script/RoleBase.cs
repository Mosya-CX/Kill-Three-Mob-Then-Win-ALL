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
    public Animator animator;// 获取动画机
    public int lastHP;// 血量变动前的上一次血量
    public int lastShield;// 护盾值变动前的上一次护盾值

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
        //更新血条Slider
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
                    obj.GetComponent<RectTransform>().anchoredPosition = new Vector2(Random.Range(-450, -150), Random.Range(300, 401));// 在某个区域内随机生成位置
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
                    obj.GetComponent<RectTransform>().anchoredPosition = new Vector2(Random.Range(-450, -150), Random.Range(300, 401));// 在某个区域内随机生成位置
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

        // 更新血量和护盾值
        if (curHP != HPSlider.value)
        {
            
            // 此处是血条渐变
            if (curHP > HPSlider.value)
            {
                
                HPSlider.value += Time.deltaTime * 30;
                if (curHP != lastHP && GameManager.Instance.isFighting)
                {
                    // 生成回复数字物体
                    CreateRecoverNum();

                    lastHP = curHP;
                }
            }
            else if (curHP < HPSlider.value)
            {
                if (curHP != lastHP && GameManager.Instance.isFighting)
                {
                    // 生成伤害数字物体 
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
            // 玩家死亡后触发的功能逻辑
            if (tag == "Player")
            {
                // 检测是否有浴火重生buff
                if (buffList.Contains(3004))
                {
                    maxHP -= 10;
                    curHP = maxHP;
                }
                else
                {
                    //播放死亡音效
                    AudioManager.Instance.PlayerDeathAudio();
                    //切换到失败状态
                    FightManager.Instance.ChangeType(FightType.Lose);
                }
            }
            else if (tag == "Enemy")
            {
                //触发贪的特殊效果
                if(name == "贪")
                {
                    FightCardManager.instance.availableCardList.Add("1017");
                    //Debug.Log("贪心！");
                }
                //避免嗔的效果特殊效果持续
                else if (name== "嗔")
                {
                    bool isCharging = GetComponent<Boss2AI>().isCharging;
                    if (isCharging)
                    {
                        GameManager.Instance.player.totalFee++;
                    }
                }
                // 播放敌人死亡动画

                // 移除敌人
                GameManager.Instance.enemy = null;

                //切换到胜利状态
                FightManager.Instance.ChangeType(FightType.Win);

                Destroy(gameObject);
            }
        }
    }

    public void CreateRecoverNum()
    {
        // 生成回血数字物体 
        GameObject obj = GameObject.Instantiate(Resources.Load("Prefab/Item/DamageNum")) as GameObject;
        obj.transform.SetParent(GameObject.Find("UI").transform, false);
        if (gameObject.tag == "Player")
        {
            obj.GetComponent<RectTransform>().anchoredPosition = new Vector2(Random.Range(-450, -150), Random.Range(300, 401));// 在某个区域内随机生成位置
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
            obj.GetComponent<RectTransform>().anchoredPosition = new Vector2(Random.Range(-450, -150), Random.Range(300, 401));// 在某个区域内随机生成位置
        }
        else if (gameObject.tag == "Enemy")
        {
            obj.GetComponent<RectTransform>().anchoredPosition = new Vector2(Random.Range(150, 450), Random.Range(300, 401));
        }
        obj.GetComponent<TMP_Text>().text = (curHP - lastHP).ToString();
        obj.GetComponent<TMP_Text>().color = Color.red;
        
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

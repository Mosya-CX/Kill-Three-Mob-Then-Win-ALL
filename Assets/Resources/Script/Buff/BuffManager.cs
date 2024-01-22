using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 用id指代buff
//Id    Name	    Des	                                                             Target
//3000	火元素	    附着火元素	                                                     敌人
//3001	水元素	    附着水元素	                                                     敌人
//3002	草元素	    附着草元素	                                                     敌人
//3003	火花	    回合结束后造成1点火元素伤害	                                     敌人
//3004	浴火重生	阵亡后可复活，但是永久-10最大生命上限，回复100%最大生命值	     玩家
//3005	浊流	    并在该场战斗内敌人永远存在3001号Buff	                         敌人
//3006	水之屏障	回合结束后造成3点水元素伤害	                                     敌人
//3007	萤草	    下回合多抽取2张牌	                                             玩家
//3008	解放	    下回合额外获得两点费用	                                         玩家



public class BuffManager : MonoBehaviour 
{
    public static BuffManager Instance;

   

    public Player playerData;
    public Enemy enemyData;
    public List<int> playerBuffList;
    public List<int> enemyBuffList;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        
    }

    private void Update()
    {
      
        // 检测是否玩家和敌人数据是否绑定
        if (GameManager.Instance.isFighting)
        {
            if (playerBuffList == null || playerData == null)
            {
                playerData = GameManager.Instance.player;
                playerBuffList = playerData.buffList;
            }
            if (enemyBuffList == null || enemyData == null)
            {
                enemyData = GameManager.Instance.enemy;
                enemyBuffList = enemyData.buffList;
            }
        }
        
       
        // 检测敌人身上的buff
        if (enemyBuffList != null)
        {
            // 检测是否存在浊流buff
            if (enemyBuffList.Contains(3005))
            {
                
                // 加水元素
                if (!enemyBuffList.Contains(3001))
                {

                    enemyBuffList.Add(3001);
                }
            }

            // 检测敌人身上的元素反应
            if (enemyBuffList.Contains(3000) && enemyBuffList.Contains(3001))
            {

                // 火加水
                playerData.Shield += 8;
                if (enemyData.Shield >= 8)
                {
                    playerData.Shield -= 8;
                }
                else if (enemyData.Shield < 8 && enemyData.Shield > 0)
                {
                    enemyData.curHP -= 8 - enemyData.Shield;
                    enemyData.Shield = 0;
                }
                else
                {
                    enemyData.curHP -= 8;
                }
                DelBuff(enemyData.gameObject, 3000);
                DelBuff(enemyData.gameObject, 3001);
            }
            else if (enemyBuffList.Contains(3001) && enemyBuffList.Contains(3002))
            {
                // 水加草
                playerData.currentFee++;
                DelBuff(enemyData.gameObject, 3001);
                DelBuff(enemyData.gameObject, 3002);
            }
            else if (enemyBuffList.Contains(3000) && enemyBuffList.Contains(3002))
            {
                // 火加草
                playerData.curHP += 10;
                DelBuff(enemyData.gameObject, 3000);
                DelBuff(enemyData.gameObject, 3002);
                
            }
        }
        

    
    }

    // 添加buff
    public void AddBuff(GameObject target, int buffId)
    {
        if (target.tag == "Player")
        {
            if (playerBuffList.Contains(buffId))
            {
                return;
            }
            else
            {
                // 加载ui
                GameObject obj = GameObject.Instantiate(Resources.Load("Prefab/UI/" + buffId.ToString())) as GameObject;
                obj.GetComponent<RectTransform>().anchoredPosition = new Vector2(80, 70);
                obj.transform.SetParent(GameObject.Find("UI/FightUI/Middle/PlayerStack").transform, false);
                obj.name = buffId.ToString();

                playerData.buffList.Add(buffId);
            }
            
        }
        else if (target.tag == "Enemy")
        {
            if (enemyBuffList.Contains(buffId))
            {
                return;
            }
            else
            {
                // 加载ui
                GameObject obj = GameObject.Instantiate(Resources.Load("Prefab/UI/" + buffId.ToString())) as GameObject;
                obj.GetComponent<RectTransform>().anchoredPosition = new Vector2(80, 70);
                obj.transform.SetParent(GameObject.Find("UI/FightUI/Middle/EnemyStack").transform, false);
                obj.name = buffId.ToString();

                enemyData.buffList.Add(buffId);
            }
            
        }
    }
    // 删除buff
    public void DelBuff(GameObject target, int buffId)
    {
        if (target.tag == "Player")
        {
            // 删除ui物体
            GameObject obj = GameObject.Find("UI/FightUI/Middle/PlayerStack/" + buffId);
            obj.GetComponent<BaseBuff>().Dele();
            //obj.name = "None";
            //obj.SetActive(false);

            playerBuffList.RemoveAt(enemyBuffList.IndexOf(buffId));
        }
        else if (target.tag == "Enemy")
        {

            // 删除ui物体
            GameObject obj = GameObject.Find("UI/FightUI/Middle/EnemyStack/" + buffId);
            obj.GetComponent<BaseBuff>().Dele();
            //obj.name = "None";
            //obj.SetActive(false) ;


            enemyBuffList.RemoveAt(enemyBuffList.IndexOf(buffId));
        }
    }
}

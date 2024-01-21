using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 用id指代buff
//Id    Name		Des
//3000	火元素		附着火元素
//3001	水元素		附着水元素
//3002	草元素		附着草元素
//3004	浴火重生	阵亡后可复活，但是永久-10最大生命上限，回复100%最大生命值
//3005	浊流		该场战斗内敌人永远存在水附着Buff



public class BuffManager
{
    public static BuffManager instance = new BuffManager();

    public static BuffManager Instance
    {
        get
        {
            return instance;
        }
    }

    public Player playerData;
    public Enemy enemyData;
    public List<int> playerBuffList;
    public List<int> enemyBuffList;

    private void Start()
    {
        playerData = GameManager.Instance.player;
        enemyData = GameManager.Instance.enemy;
        playerBuffList = playerData.buffList;
        enemyBuffList = enemyData.buffList;
    }

    private void Update()
    {
        
        if (enemyBuffList.Contains(3005))
        {
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
            enemyBuffList.Remove(enemyBuffList.IndexOf(3000));
            enemyBuffList.Remove(enemyBuffList.IndexOf(3001));
        }
        else if (enemyBuffList.Contains(3001) && enemyBuffList.Contains(3002))
        {
            // 水加草
            playerData.currentFee++;
            enemyBuffList.Remove(enemyBuffList.IndexOf(3001));
            enemyBuffList.Remove(enemyBuffList.IndexOf(3002));
        }
        else if (enemyBuffList.Contains(3000) && enemyBuffList.Contains(3002))
        {
            // 火加草
            playerData.curHP += 10;
            enemyBuffList.Remove(enemyBuffList.IndexOf(3000));
            enemyBuffList.Remove(enemyBuffList.IndexOf(3002));
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
                playerData.buffList.Add(buffId);
            }
            
        }
        else if (target.tag == "Enemy")
        {
            if (playerBuffList.Contains(buffId))
            {
                return;
            }
            else
            {
                enemyData.buffList.Add(buffId);
            }
            
        }
    }
    // 删除buff
    public void DelBuff(GameObject target, int buffId)
    {
        if (target.tag == "Player")
        {
            playerBuffList.Remove(enemyBuffList.IndexOf(buffId));
        }
        else if (target.tag == "Enemy")
        {
            enemyBuffList.Remove(enemyBuffList.IndexOf(buffId));
        }
    }
}

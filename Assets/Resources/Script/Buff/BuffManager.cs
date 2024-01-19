using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 用id指代buff
//Id    Name		Des
//3000	火元素		附着火元素
//3001	水元素		附着水元素
//3002	草元素		附着草元素
//3003	减伤		敌人嗔2001的4技能会使得玩家的可造成的伤害减半
//3004	浴火重生	每回合得到一张1008号卡牌。阵亡后可复活，但是永久-10最大生命上限，回复50%最大生命值
//3005	浊流1		抵消下一次伤害
//3006	浊流2		该场战斗内敌人永远存在3001号水附着Buff
//3007	落叶归根	每使用一张草属性的卡牌，下回合获得一张1014/1015号卡牌


public class BuffManager : MonoBehaviour
{
    public static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            return instance;
        }
    }

    Player playerData;
    Enemy enemyData;
    List<int> playerBuffList;
    List<int> enemyBuffList;

    private void Start()
    {
        playerData = GameManager.instance.Player.GetComponent<Player>();
        enemyData = GameManager.instance.Enemy.GetComponent<Enemy>();
        playerBuffList = playerData.buffList;
        enemyBuffList = enemyData.buffList;
    }

    private void Update()
    {
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
            playerData.buffList.Add(buffId);
        }
        else if (target.tag == "Enemy")
        {
            enemyData.buffList.Add(buffId);
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

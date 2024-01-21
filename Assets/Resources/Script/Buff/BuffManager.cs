using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ��idָ��buff
//Id    Name		Des
//3000	��Ԫ��		���Ż�Ԫ��
//3001	ˮԪ��		����ˮԪ��
//3002	��Ԫ��		���Ų�Ԫ��
//3004	ԡ������	������ɸ����������-10����������ޣ��ظ�100%�������ֵ
//3005	����		�ó�ս���ڵ�����Զ����ˮ����Buff



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
        // ���������ϵ�Ԫ�ط�Ӧ
        if (enemyBuffList.Contains(3000) && enemyBuffList.Contains(3001))
        {
            // ���ˮ
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
            // ˮ�Ӳ�
            playerData.currentFee++;
            enemyBuffList.Remove(enemyBuffList.IndexOf(3001));
            enemyBuffList.Remove(enemyBuffList.IndexOf(3002));
        }
        else if (enemyBuffList.Contains(3000) && enemyBuffList.Contains(3002))
        {
            // ��Ӳ�
            playerData.curHP += 10;
            enemyBuffList.Remove(enemyBuffList.IndexOf(3000));
            enemyBuffList.Remove(enemyBuffList.IndexOf(3002));
        }

    
    }

    // ���buff
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
    // ɾ��buff
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

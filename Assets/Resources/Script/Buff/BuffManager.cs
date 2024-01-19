using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ��idָ��buff
//Id    Name		Des
//3000	��Ԫ��		���Ż�Ԫ��
//3001	ˮԪ��		����ˮԪ��
//3002	��Ԫ��		���Ų�Ԫ��
//3003	����		������2001��4���ܻ�ʹ����ҵĿ���ɵ��˺�����
//3004	ԡ������	ÿ�غϵõ�һ��1008�ſ��ơ�������ɸ����������-10����������ޣ��ظ�50%�������ֵ
//3005	����1		������һ���˺�
//3006	����2		�ó�ս���ڵ�����Զ����3001��ˮ����Buff
//3007	��Ҷ���	ÿʹ��һ�Ų����ԵĿ��ƣ��»غϻ��һ��1014/1015�ſ���


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
            playerData.buffList.Add(buffId);
        }
        else if (target.tag == "Enemy")
        {
            enemyData.buffList.Add(buffId);
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

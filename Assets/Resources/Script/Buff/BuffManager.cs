using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ��idָ��buff
//Id    Name	    Des	                                                             Target
//3000	��Ԫ��	    ���Ż�Ԫ��	                                                     ����
//3001	ˮԪ��	    ����ˮԪ��	                                                     ����
//3002	��Ԫ��	    ���Ų�Ԫ��	                                                     ����
//3003	��	    �غϽ��������1���Ԫ���˺�	                                     ����
//3004	ԡ������	������ɸ����������-10����������ޣ��ظ�100%�������ֵ	     ���
//3005	����	    ���ڸó�ս���ڵ�����Զ����3001��Buff	                         ����
//3006	ˮ֮����	�غϽ��������3��ˮԪ���˺�	                                     ����
//3007	ө��	    �»غ϶��ȡ2����	                                             ���
//3008	���	    �»غ϶������������	                                         ���



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
      
        // ����Ƿ���Һ͵��������Ƿ��
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
        
       
        // ���������ϵ�buff
        if (enemyBuffList != null)
        {
            // ����Ƿ��������buff
            if (enemyBuffList.Contains(3005))
            {
                
                // ��ˮԪ��
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
                DelBuff(enemyData.gameObject, 3000);
                DelBuff(enemyData.gameObject, 3001);
            }
            else if (enemyBuffList.Contains(3001) && enemyBuffList.Contains(3002))
            {
                // ˮ�Ӳ�
                playerData.currentFee++;
                DelBuff(enemyData.gameObject, 3001);
                DelBuff(enemyData.gameObject, 3002);
            }
            else if (enemyBuffList.Contains(3000) && enemyBuffList.Contains(3002))
            {
                // ��Ӳ�
                playerData.curHP += 10;
                DelBuff(enemyData.gameObject, 3000);
                DelBuff(enemyData.gameObject, 3002);
                
            }
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
                // ����ui
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
                // ����ui
                GameObject obj = GameObject.Instantiate(Resources.Load("Prefab/UI/" + buffId.ToString())) as GameObject;
                obj.GetComponent<RectTransform>().anchoredPosition = new Vector2(80, 70);
                obj.transform.SetParent(GameObject.Find("UI/FightUI/Middle/EnemyStack").transform, false);
                obj.name = buffId.ToString();

                enemyData.buffList.Add(buffId);
            }
            
        }
    }
    // ɾ��buff
    public void DelBuff(GameObject target, int buffId)
    {
        if (target.tag == "Player")
        {
            // ɾ��ui����
            GameObject obj = GameObject.Find("UI/FightUI/Middle/PlayerStack/" + buffId);
            obj.GetComponent<BaseBuff>().Dele();
            //obj.name = "None";
            //obj.SetActive(false);

            playerBuffList.RemoveAt(enemyBuffList.IndexOf(buffId));
        }
        else if (target.tag == "Enemy")
        {

            // ɾ��ui����
            GameObject obj = GameObject.Find("UI/FightUI/Middle/EnemyStack/" + buffId);
            obj.GetComponent<BaseBuff>().Dele();
            //obj.name = "None";
            //obj.SetActive(false) ;


            enemyBuffList.RemoveAt(enemyBuffList.IndexOf(buffId));
        }
    }
}

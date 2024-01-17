using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffManager 
{
    public static BuffManager Instance = new BuffManager();
    
    // ��ָ����ɫ���Buff
    public void AddBuff(GameObject Character, BaseBuff Buff)
    {
        if (Character.tag == "Player")
        {
            Character.GetComponent<Player>().Buffs.Add(Buff);
        }
        else if (Character.tag == "Enemy")
        {
            Character.GetComponent<Enemy>().Buffs.Add(Buff);
        }
    }
    // ɾ��ָ����ɫ��Buff
    public void DelBuff(GameObject Character, BaseBuff Buff)
    {
        if (Character.tag == "Player")
        {
            Character.GetComponent<Player>().Buffs.Remove(Buff);
        }
        else if (Character.tag == "Enemy")
        {
            Character.GetComponent<Enemy>().Buffs.Remove(Buff);
        }
    }

    // ���Ŀ���ɫ��״̬
    public void MonitorBuff(GameObject Character)
    {
        if (Character.tag == "Player")
        {
            List<BaseBuff> tarBuffList = Character.GetComponent<Player>().Buffs;
            for (int i = 0; i < tarBuffList.Count; i++)
            {
                tarBuffList[i].Active("Player");
                tarBuffList[i].Fun(Character);
            }
        }
        else if (Character.tag == "Enemy")
        {
            List<BaseBuff> tarBuffList = Character.GetComponent<Enemy>().Buffs;
            for (int i = 0; i < tarBuffList.Count; i++)
            {
                tarBuffList[i].Active("Enemy");
                tarBuffList[i].Fun(Character);
            }
        }
        
    }

}

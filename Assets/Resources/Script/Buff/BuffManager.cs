using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffManager 
{
    public static BuffManager Instance = new BuffManager();
    
    // 向指定角色添加Buff
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
    // 删除指定角色的Buff
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

    // 检测目标角色的状态
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

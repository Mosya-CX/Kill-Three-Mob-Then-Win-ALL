using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffManager 
{
    public static BuffManager Instance = new BuffManager();

    // 给部分buff使用的数值参数
    public int burningDamage = 10;
    // 以下为一些通用参数随时可调
    public int Value1;
    public int Value2;
    public int Value3;

    // 向指定角色添加Buff
    public void AddBuff(GameObject Character, int Id, int lastTime)
    {
        BaseBuff newBuff = new BaseBuff(Id, lastTime);
        newBuff.Active(Character.tag);
        if (Character.tag == "Player")
        {
            Character.GetComponent<Player>().Buffs.Add(newBuff);
        }
        else if (Character.tag == "Enemy")
        {
            Character.GetComponent<Enemy>().Buffs.Add(newBuff);
        }
    }
    // 删除指定角色的Buff
    public void DelBuff(GameObject Character, int Id)
    {
        List<BaseBuff> list =  null;
        if (Character.tag == "Player")
        {
            list = Character.GetComponent<Player>().Buffs;
        }
        else if (Character.tag == "Enemy")
        {
            list = Character.GetComponent<Enemy>().Buffs;
        }
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i].id == Id)
            {
                list[i].Destory(Character.tag);
                list.Remove(list[i]);                
                return;
            }
        }
    }

    // 检测角色的状态并结算
    public void DetectBuff(GameObject Character)
    {
        bool isBuff1 = false;// 火元素
        bool isBuff2 = false;// 水元素
        bool isBuff3 = false;// 草元素
        bool isBuff4 = false;// 减攻击力
        bool isBuff5 = false;// 燃烧状态
        bool isBuff6 = false;// 加攻击力
        bool isBuff7 = false;// 禁止使用护盾
        List<BaseBuff> buffList = null;
        if (Character.tag == "Player")
        {
            buffList = Character.GetComponent<Player>().Buffs;
        }
        else if (Character.tag == "Enemy")
        {
            buffList = Character.GetComponent<Enemy>().Buffs;
        }
        for (int i = 0;i < buffList.Count;i++)
        {
            if (buffList[i].id == 1)
            {
                isBuff1 = true;
            }
            if (buffList[i].id == 2)
            {
                isBuff2 = true;
            }
            if (buffList[i].id == 3)
            {
                isBuff3 = true;
            }
            if (buffList[i].id == 4)
            {
                isBuff4 = true;
            }
            if (buffList[i].id == 5)
            {
                isBuff5 = true;
            }
            if (buffList[i].id == 6)
            {
                isBuff6 = true;
            }
            if (buffList[i].id == 7)
            {
                isBuff7 = true;
            }
            buffList[i].lastTime--;
            if (buffList[i].lastTime <= 0)
            {
                buffList[i].Destory(Character.tag);
            }
        }
        if (isBuff1 && isBuff2)
        {
            // 火加水的buff逻辑
        }
        if (isBuff1 && isBuff3)
        {
            // 火加草的buff逻辑
            AddBuff(Character, 5, 1);
        }
        if (isBuff2 && isBuff3)
        {
            // 草加水的buff逻辑
        }
        if (isBuff4)
        {
            // 减攻击力的buff逻辑
            if (Character.tag == "Player")
            {
                Character.GetComponent<Player>().finalDemage -= Value1;
            }
            else if (Character.tag == "Enemy")
            {
                Character.GetComponent<Enemy>().finalDemage -= Value1;
            }
        }
        if (isBuff5)
        {
            // 燃烧的buff逻辑
            if (Character.tag == "Player")
            {
                Character.GetComponent<Player>().HP -= burningDamage;
            }
            else if (Character.tag == "Enemy")
            {
                Character.GetComponent<Enemy>().HP -= burningDamage;
            }
        }
        if (isBuff6)
        {
            // 加攻击力的buff逻辑
            if (Character.tag == "Player")
            {
                Character.GetComponent<Player>().finalDemage += Value2;
            }
            else if (Character.tag == "Enemy")
            {
                Character.GetComponent<Enemy>().finalDemage += Value2;
            }
        }
        if (isBuff7)
        {
            // 禁止使用护盾的buff逻辑
        }
    }

}

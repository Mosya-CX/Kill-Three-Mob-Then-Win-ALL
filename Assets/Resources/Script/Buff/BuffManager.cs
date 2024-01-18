using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffManager 
{
    public static BuffManager Instance = new BuffManager();

    // ������buffʹ�õ���ֵ����
    public int burningDamage = 10;
    // ����ΪһЩͨ�ò�����ʱ�ɵ�
    public int Value1;
    public int Value2;
    public int Value3;

    // ��ָ����ɫ���Buff
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
    // ɾ��ָ����ɫ��Buff
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

    // ����ɫ��״̬������
    public void DetectBuff(GameObject Character)
    {
        bool isBuff1 = false;// ��Ԫ��
        bool isBuff2 = false;// ˮԪ��
        bool isBuff3 = false;// ��Ԫ��
        bool isBuff4 = false;// ��������
        bool isBuff5 = false;// ȼ��״̬
        bool isBuff6 = false;// �ӹ�����
        bool isBuff7 = false;// ��ֹʹ�û���
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
            // ���ˮ��buff�߼�
        }
        if (isBuff1 && isBuff3)
        {
            // ��Ӳݵ�buff�߼�
            AddBuff(Character, 5, 1);
        }
        if (isBuff2 && isBuff3)
        {
            // �ݼ�ˮ��buff�߼�
        }
        if (isBuff4)
        {
            // ����������buff�߼�
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
            // ȼ�յ�buff�߼�
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
            // �ӹ�������buff�߼�
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
            // ��ֹʹ�û��ܵ�buff�߼�
        }
    }

}

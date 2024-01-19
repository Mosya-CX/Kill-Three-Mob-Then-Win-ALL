using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "����buff����", menuName = "Buffϵͳ")]
public class BuffData : ScriptableObject
{
    public int id;
    public string Name;
    public string Des;
    public string iconPath;
    public int duration;// buff����ʱ��
    public int maxStack;// ����������
    public bool isForever;// �ж��Ƿ���������buff
    // ���·�ʽ
    public BuffUpdateTime buffUpdateTime;// ��buff�ĸ��·�ʽ
    public BuffStackRemoveUpdate buffStackRemoveUpdate;// ��buff�ĸ��·�ʽ

    public BaseBuffModel onCreate;
    public BaseBuffModel onRemove;
    public BaseBuffModel onTick;// buffЧ������ʱ����

    public BaseBuffModel onHit;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffHandler : MonoBehaviour
{
    // �洢buff��Ϣ
    public LinkedList<BuffInfo> buffList = new LinkedList<BuffInfo>();

    private void Update()
    {
        // ���buff
        MonitorBuff();
    }

    void MonitorBuff()
    {
        List<BuffInfo> deleList = new List<BuffInfo>();
        foreach (var buffInfo in buffList)
        {
            if (buffInfo.durationTimer <= 0)
            {
                deleList.Add(buffInfo);
            }
        }
        foreach (var buffInfo in deleList)
        {
            RemoveBuff(buffInfo);
        }
        // �������ڼ��Ԫ�ط�Ӧ

    }

    public void AddBuff(BuffInfo buffInfo)
    {
        BuffInfo findBuffInfo = FindBuff(buffInfo.buffData.id);
        if (findBuffInfo != null)
        {
            // ��Ϊ����buff�Ѵ���
            if (findBuffInfo.curStack < findBuffInfo.buffData.maxStack)
            {
                findBuffInfo.curStack++;
                switch (findBuffInfo.buffData.buffUpdateTime)
                {
                    case BuffUpdateTime.Add:
                        buffInfo.durationTimer += buffInfo.buffData.duration;
                        break;
                    case BuffUpdateTime.Replace:
                        buffInfo.durationTimer = buffInfo.buffData.duration;
                        break;
                    case BuffUpdateTime.Keep: break;
                }
       
                findBuffInfo.buffData.onCreate.Apply(findBuffInfo);
            }
        }
        else
        {
            buffInfo.curStack = 1;
            buffInfo.durationTimer = buffInfo.buffData.duration;

            buffInfo.buffData.onCreate.Apply(buffInfo);
            // ��ӵ�buffList
            buffList.AddLast(buffInfo);
            // ����
            BuffListSort(buffList);
        }
    }

    public void RemoveBuff(BuffInfo buffInfo)
    {
        switch (buffInfo.buffData.buffStackRemoveUpdate)
        {
            case BuffStackRemoveUpdate.Clear:
                buffInfo.buffData.onRemove.Apply(buffInfo);
                buffList.Remove(buffInfo);
                break;
            case BuffStackRemoveUpdate.Reduce:
                buffInfo.curStack--;
                buffInfo.buffData.onRemove.Apply(buffInfo);
                if (buffInfo.curStack == 0)
                {
                    buffList.Remove(buffInfo);
                }
                break;
        }
    }

    public BuffInfo FindBuff(int buffId)
    {
        foreach (BuffInfo buffInfo in buffList)
        {
            if (buffInfo.buffData.id == buffId)
            {
                return buffInfo;
            }
        }
        return default;
    }

    void BuffListSort(LinkedList<BuffInfo> list)
    {
        if (list == null || list.First == null)
        {
            return;
        }
        LinkedListNode<BuffInfo> cur = list.First.Next;

        while (cur != null)
        {
            LinkedListNode<BuffInfo> next = cur.Next;
            LinkedListNode<BuffInfo> prev = cur.Previous;

            while (prev != null && prev.Value.buffData.id > cur.Value.buffData.id)
            {
                prev = prev.Previous;
            }
            if (prev == null)
            {
                list.Remove(cur);
                list.AddFirst(cur);
            }
            else
            {
                list.Remove(cur);
                list.AddAfter(prev, cur);
            }
            cur = next;
        }
    }
}

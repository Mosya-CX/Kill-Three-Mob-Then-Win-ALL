using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "创建buff数据", menuName = "Buff系统")]
public class BuffData : ScriptableObject
{
    public int id;
    public string Name;
    public string Des;
    public string iconPath;
    public int duration;// buff持续时间
    public int maxStack;// 最大层数层数
    public bool isForever;// 判断是否是永久性buff
    // 更新方式
    public BuffUpdateTime buffUpdateTime;// 加buff的更新方式
    public BuffStackRemoveUpdate buffStackRemoveUpdate;// 减buff的更新方式

    public BaseBuffModel onCreate;
    public BaseBuffModel onRemove;
    public BaseBuffModel onTick;// buff效果触发时调用

    public BaseBuffModel onHit;
}

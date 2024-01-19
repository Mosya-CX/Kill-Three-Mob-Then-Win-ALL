

using UnityEngine;

public enum BuffUpdateTime
{
    Add,
    Replace,
    Keep,
}

public enum BuffStackRemoveUpdate
{
    Clear,
    Reduce,
}

public class BuffInfo
{
    public BuffData buffData;
    public GameObject Creator;
    public GameObject Target;
    public int durationTimer;// 计时器
    public int curStack;// 当前层数
}

public class DamageInfo
{
    public GameObject Creator;
    public GameObject Target;
    public int Damage;
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//战斗单元
public class FightUnit : MonoBehaviour
{
    public virtual void Init() {}   //初始化
    public virtual void OnUpdate() {}   //每帧执行

    public virtual void End() {} // 结束执行

}

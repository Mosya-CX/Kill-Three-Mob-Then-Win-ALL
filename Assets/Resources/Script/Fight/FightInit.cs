using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//����ս����ʼ��
public class FightInit : FightUnit
{
    public override void Init()
    {
        //�л�BGM

        // ��������(���GameManager��progress�жϴ���ʲô�׶Σ�ͨ��EnemyManager���LoadMob����id���ɶ�Ӧ�ĵ���)

        FightCardManager.instance.Init();
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
    }
}

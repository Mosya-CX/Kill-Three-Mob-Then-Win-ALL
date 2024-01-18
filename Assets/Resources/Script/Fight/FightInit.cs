using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//����ս����ʼ��
public class FightInit : FightUnit
{
    public override void Init()
    {
        //�л�BGM
        AudioManager.Instance.FightingAudio();
        // ��������(���GameManager��progress�жϴ���ʲô�׶Σ�ͨ��EnemyManager���LoadMob����id���ɶ�Ӧ�ĵ���)
        int progress = GameManager.Instance.currentProgress;
        if (progress == 1)
        {
            EnemyManager.Instance.LoadMob(1000);
        }
        else if (progress == 2)
        {
            EnemyManager.Instance.LoadMob(1001);
        }
        else if (progress == 3)
        {
            EnemyManager.Instance.LoadMob(1002);
        }

        // ��ʼ���������
        FightCardManager.instance.Init();
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
    }
}

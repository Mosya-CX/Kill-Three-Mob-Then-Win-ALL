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

        //��ʼ��ս����ֵ
        FightManager.Instance.Init();

        // ��������(���GameManager��progress�жϴ���ʲô�׶Σ�ͨ��EnemyManager���LoadMob����id���ɶ�Ӧ�ĵ���)
        int progress = GameManager.Instance.currentProgress;
        if (progress == 1)
        {
            EnemyManager.Instance.LoadMob("2001");
        }
        else if (progress == 2)
        {
            EnemyManager.Instance.LoadMob("2002");
        }
        else if (progress == 3)
        {
            EnemyManager.Instance.LoadMob("2003");
        }

        // ��ʼ�������ƶ�
        FightCardManager.instance.Init();

        // ��ʾս������(����Ҫ)
        // UIManager.Instance.OpenUI<FightUI>("FightUI");

        // ������ҷ�������
        GameManager.Instance.player.totalFee = 4;

        //�л�����һغ�
        FightManager.Instance.ChangeType(FightType.Player);
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
    }
}

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

        // �����ƶ�
        FightCardManager.instance.ResetHandCard();
        FightCardManager.instance.ResetUsedCard();

        // ��ʾս������()
        // UIManager.Instance.OpenUI<FightUI>("FightUI");
        GameObject.FindWithTag("FightUI").SetActive(true);
        GameObject.FindWithTag("Player").SetActive(true) ;

        // ������ҷ�������
        GameManager.Instance.player.totalFee = 4;

        //�л�����һغ�
        FightManager.Instance.ChangeType(FightType.Player);

        // �����ƶѵ�UI��ʾ
        GameObject.FindWithTag("FightUI").GetComponent<FightUI>().UpdateCardNum();
        GameObject.FindWithTag("FightUI").GetComponent<FightUI>().UpdateCardNum();
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
    }
}

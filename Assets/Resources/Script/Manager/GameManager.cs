using Excel.Log;
using OfficeOpenXml;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            return instance;
        }
    }
    // ��ǰ��Ϸ���̽���
    public int currentProgress;
    // �ж��Ƿ���ս��״̬
    public bool isFighting;

    //���Ҫ�õ���ʱ��
    float gameTime;

    // ����Һ͵���
    public GameObject Player;
    public GameObject Enemy;

    //public int currentTurn;// 0��ʾ��ս��״̬��1��ʾ��һغϣ�2��ʾ���˻غ�
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        //���ſ���bgm
        AudioManager.Instance.StartLevelAudio();

        Player = GameObject.FindWithTag("Player");
        Enemy = GameObject.FindWithTag("Enemy");


        // ��ʼ������
        currentProgress = 0;
        //// ��ʼ��ս���غ�
        //currentTurn = 0;
        // ��ʼ�����ñ�
        GameConfigManager.Instance.Init();
        // ��ʼ����Ƶ����ϵͳ

        // ��ʼ�������ƶ�
        FightCardManager.instance.Init();

        // GameConfig���ò���
        string Name = GameConfigManager.Instance.getCardById("t1")["Name"];
        print(Name);
    }

    private void Update()
    {
        gameTime += Time.deltaTime;//���Ҫ�õ���ʱ��

        switch (currentProgress)
        {
            case 0:
                break;
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
        }

        if (FightCardManager.instance.availableCardList.Count == 0)
        {
            FightCardManager.instance.ResetUsedCard();
        }

        //if (currentTurn == 0)
        //{

        //}
        //else if (currentTurn == 1)
        //{

        //}
        //else if (currentTurn == 2)
        //{

        //}
    }
}

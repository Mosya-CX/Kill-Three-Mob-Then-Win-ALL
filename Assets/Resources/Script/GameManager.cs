using Excel.Log;
using OfficeOpenXml;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = new GameManager();
    public int currentProgress;
    public bool isFighting;
    private bool fightBGMIsOn = false;
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

        // GameConfig���ò���
        string Name = GameConfigManager.Instance.getCardById("t1")["Name"];
        print(Name);
    }

    private void Update()
    {
        if (isFighting)
        {
            
        }
        /*//����ս������ս��BGM
        if (isFighting && !fightBGMIsOn)
        {
            AudioManager.Instance.FightingAudio();
            fightBGMIsOn = true;
        }*/
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

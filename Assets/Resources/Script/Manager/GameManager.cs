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
    // 当前游戏流程进度
    public int currentProgress;
    // 判断是否在战斗状态
    public bool isFighting;

    //结局要用到的时间
    float gameTime;

    // 绑定玩家和敌人
    public GameObject Player;
    public GameObject Enemy;

    //public int currentTurn;// 0表示非战斗状态，1表示玩家回合，2表示敌人回合
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
        //播放开局bgm
        AudioManager.Instance.StartLevelAudio();

        Player = GameObject.FindWithTag("Player");
        Enemy = GameObject.FindWithTag("Enemy");


        // 初始化进度
        currentProgress = 0;
        //// 初始化战斗回合
        //currentTurn = 0;
        // 初始化配置表
        GameConfigManager.Instance.Init();
        // 初始化音频管理系统

        // 初始化可用牌堆
        FightCardManager.instance.Init();

        // GameConfig配置测试
        string Name = GameConfigManager.Instance.getCardById("t1")["Name"];
        print(Name);
    }

    private void Update()
    {
        gameTime += Time.deltaTime;//结局要用到的时间

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

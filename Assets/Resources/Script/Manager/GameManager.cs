using Excel.Log;
using OfficeOpenXml;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    //public static GameManager Instance
    //{
    //    get
    //    {
    //        return instance;
    //    }
    //    set
    //    {
    //        instance = value;
    //    }
    //}
    // 当前游戏流程进度
    public int currentProgress;
    // 当前回合
    public int turn;
    // 判断是否在战斗状态
    public bool isFighting;

    //结局要用到的时间
    float gameTime;

    // 绑定玩家和敌人
    public Player player;
    public Enemy enemy;
    
    //public int currentTurn;// 0表示非战斗状态，1表示玩家回合，2表示敌人回合
    private void Awake()
    {
        Instance = this;

        Instance = this;

        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        //播放开局bgm
        AudioManager.Instance.StartLevelAudio();

        isFighting = false;

        // 初始化进度
        currentProgress = 0;
        // 初始化战斗回合
        turn = 0;

        // 初始化配置表
        GameConfigManager.Instance.Init();
        // 初始化音频管理系统

        // 初始化可用牌堆
        FightCardManager.instance.Init();

        // GameConfig配置测试


        //显示LoginUI
        UIManager.Instance.OpenUI<LoginUI>("LoginUI");


        // 目前还没玩家预制体
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        if (player == null)
        {
            // 生成玩家对象
            Vector2 playerPos = new Vector2(-5, 0);//玩家位置
            GameObject obj = GameObject.Instantiate(Resources.Load("Prefab/Player")) as GameObject;
            obj.transform.position = playerPos;
            player = obj.GetComponent<Player>();
            obj.name = "Player";
        }

        if (player != null && BuffManager.Instance.playerData == null)
        {
            BuffManager.Instance.playerData = player;
        }

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


        //if (FightCardManager.instance.availableCardList.Count == 0)
        //{
        //    Debug.Log(1);
        //    FightCardManager.instance.ResetUsedCard();
        //    Debug.Log(4);
        //}

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

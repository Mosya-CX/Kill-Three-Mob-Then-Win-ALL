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
    // 方便调用玩家和敌人
    public GameObject Player;
    public GameObject Enemy;

    //public int currentTurn;// 0表示非战斗状态，1表示玩家回合，2表示敌人回合
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        Player = GameObject.FindWithTag("Player");
        Enemy = GameObject.FindWithTag("Enemy");
        // 初始化进度
        currentProgress = 0;
        //// 初始化战斗回合
        //currentTurn = 0;
        // 初始化配置表
        GameConfigManager.Instance.Init();
        // 初始化音频管理系统

        // GameConfig配置测试
        string Name = GameConfigManager.Instance.getCardById("t1")["Name"];
        print(Name);
    }

    private void Update()
    {
        //if (isFighting)
        //{
        //    Enemy = GameObject.FindWithTag("Enemy");
        //}
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
    // 查找敌人
    public void FindTarWithTag()
    {
        Enemy =  GameObject.FindWithTag("Ememy");
    }
}

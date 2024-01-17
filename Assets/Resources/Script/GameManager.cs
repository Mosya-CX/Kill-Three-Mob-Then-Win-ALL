using Excel.Log;
using OfficeOpenXml;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        // 初始化配置表
        GameConfigManager.Instance.Init();
        // 初始化音频管理系统

        // GameConfig配置测试
        string Name = GameConfigManager.Instance.getCardById("t1")["Name"];
        print(Name);
    }
    
}

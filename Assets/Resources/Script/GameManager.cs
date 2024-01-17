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
        // ��ʼ�����ñ�
        GameConfigManager.Instance.Init();
        // ��ʼ����Ƶ����ϵͳ

        // GameConfig���ò���
        string Name = GameConfigManager.Instance.getCardById("t1")["Name"];
        print(Name);
    }
    
}

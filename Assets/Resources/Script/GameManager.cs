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
    // ���������Һ͵���
    public GameObject Player;
    public GameObject Enemy;

    //public int currentTurn;// 0��ʾ��ս��״̬��1��ʾ��һغϣ�2��ʾ���˻غ�
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
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
    // ���ҵ���
    public void FindTarWithTag()
    {
        Enemy =  GameObject.FindWithTag("Ememy");
    }
}

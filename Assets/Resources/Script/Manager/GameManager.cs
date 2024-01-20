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
        //if (Instance != null)
        //{
        //    Destroy(gameObject);
        //    return;
        //}

        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        // ����
        Debug.Log("0");
        //���ſ���bgm
        AudioManager.Instance.StartLevelAudio();


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
        string Name = GameConfigManager.Instance.getCardById("1000")["Name"];
        print(Name);

        //��ʾLoginUI
        UIManager.Instance.OpenUI<LoginUI>("LoginUI");



        //// Ŀǰ��û���Ԥ����
        //Player = GameObject.FindWithTag("Player");
        //if (Player == null)
        //{
        //    // ������Ҷ���
        //    Vector2 playerPos = new Vector2(-5, 0.8f);//���λ�ã���δȷ��
        //    GameObject obj = GameObject.Instantiate(Resources.Load("Prefab/Player")) as GameObject;
        //    obj.transform.position = playerPos;
        //    Player = obj;
        //} 
    }

    private void Update()
    {
        gameTime += Time.deltaTime;//���Ҫ�õ���ʱ��

        switch (currentProgress)
        {
            case 0:
                break;
            case 1:
                if (Enemy == null)
                {
                    EnemyManager.Instance.LoadMob(3000);
                }
                break;
            case 2:
                if (Enemy == null)
                {
                    EnemyManager.Instance.LoadMob(3001);
                }
                break;
            case 3:
                if (Enemy == null)
                {
                    EnemyManager.Instance.LoadMob(3002);
                }
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

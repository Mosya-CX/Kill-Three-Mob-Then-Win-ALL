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
    // ��ǰ��Ϸ���̽���
    public int currentProgress;
    // ��ǰ�غ�
    public int turn;
    // �ж��Ƿ���ս��״̬
    public bool isFighting;

    //���Ҫ�õ���ʱ��
    float gameTime;

    // ����Һ͵���
    public Player player;
    public Enemy enemy;
    
    //public int currentTurn;// 0��ʾ��ս��״̬��1��ʾ��һغϣ�2��ʾ���˻غ�
    private void Awake()
    {
        Instance = this;

        Instance = this;

        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        //���ſ���bgm
        AudioManager.Instance.StartLevelAudio();

        isFighting = false;

        // ��ʼ������
        currentProgress = 0;
        // ��ʼ��ս���غ�
        turn = 0;

        // ��ʼ�����ñ�
        GameConfigManager.Instance.Init();
        // ��ʼ����Ƶ����ϵͳ

        // ��ʼ�������ƶ�
        FightCardManager.instance.Init();

        // GameConfig���ò���


        //��ʾLoginUI
        UIManager.Instance.OpenUI<LoginUI>("LoginUI");


        // Ŀǰ��û���Ԥ����
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        if (player == null)
        {
            // ������Ҷ���
            Vector2 playerPos = new Vector2(-5, 0);//���λ��
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

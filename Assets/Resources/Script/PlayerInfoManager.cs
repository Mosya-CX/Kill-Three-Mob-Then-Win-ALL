using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfoManager
{
    public static PlayerInfoManager Instance = new PlayerInfoManager();
    // �洢����
    public List<string> handCards;
    // ���ó�ʼ����
    public void Init()
    {
        handCards = new List<string>();
        // ����handCards.Add("����id");
    }


}

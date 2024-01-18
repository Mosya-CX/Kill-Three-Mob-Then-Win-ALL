using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfoManager
{
    public static PlayerInfoManager Instance = new PlayerInfoManager();
    // ¥Ê¥¢ ÷≈∆
    public List<string> handCards;
    // …Ë÷√≥ı º ÷≈∆
    public void Init()
    {
        handCards = new List<string>();
        // ¿˝£∫handCards.Add("ø®≈∆id");
    }


}

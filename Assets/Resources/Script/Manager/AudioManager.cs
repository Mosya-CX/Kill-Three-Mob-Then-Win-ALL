using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

/// <summary>
/// 声音管理器
/// </summary>
public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("BGM")]
    public AudioClip startBGMClip;  //开始游戏时的bgm
    public AudioClip fightBGMClip;  //进入战斗时的bgm

    [Header("音效")]
    public AudioClip deathClip;     //死亡音效
    public AudioClip winClip;       //胜利音效
    public AudioClip loseClip;      //失败音效
    public AudioClip playerHurtClip; //玩家受伤音效
    public AudioClip enemyHurtClip; //敌人受伤音效
    public AudioClip clickCardClip; //点击卡牌音效
    public AudioClip armorClip;     //获得护甲值的音效

    AudioSource bgmSource;
    AudioSource effectSource;


    private void Awake()
    {
        if (Instance != null)                    //防止AudioManager在人物死后重复生成，导致声音越来越大
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        DontDestroyOnLoad(gameObject);

        bgmSource = gameObject.AddComponent<AudioSource>();
        effectSource = gameObject.AddComponent<AudioSource>();
    }

    //开始游戏时播放bgm
    public void StartLevelAudio()
    {
        Instance.bgmSource.clip = Instance.startBGMClip;
        Instance.bgmSource.loop = true;
        Instance.bgmSource.Play();
    }

    //战斗时播放bgm
    public void FightingAudio()
    {
        Instance.bgmSource.Stop();
        Instance.bgmSource.clip = Instance.fightBGMClip;
        Instance.bgmSource.loop = true;
        Instance.bgmSource.Play();
    }

    //玩家胜利播放音效
    public void PlayerWonAudio()
    {
        Instance.effectSource.clip = Instance.winClip;
        Instance.effectSource.Play();
    }

    //玩家死亡播放音效
    public void PlayerDeathAudio()
    {
        Instance.effectSource.clip = Instance.deathClip;
        Instance.effectSource.Play();
    }

    //玩家受伤播放音效
    public void PlayerHurtAudio()
    {
        Instance.effectSource.clip = Instance.playerHurtClip;
        Instance.effectSource.Play();
    }

    //敌人受伤播放音效
    public void EnemyHurtAudio()
    {
        Instance.effectSource.clip = Instance.enemyHurtClip;
        Instance.effectSource.Play();
    }

    //点击卡牌音效
    public void ClickCardAudio()
    {
        Instance.effectSource.clip = Instance.clickCardClip;
        Instance.effectSource.Play();
    }

    //获得护甲值的音效
    public void ArmorAudio()
    {
        Instance.effectSource.clip = Instance.armorClip;
        Instance.effectSource.Play();
    }
}

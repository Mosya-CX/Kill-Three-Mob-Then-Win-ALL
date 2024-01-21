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
    public AudioClip hurtEffectClip; //受击音效
    public AudioClip hurtVoiceClip; //玩家受伤呻吟音效
    public AudioClip clickCardClip; //点击卡牌音效
    public AudioClip armorClip;     //获得护甲值的音效

    AudioSource bgmSource;
    AudioSource effect1Source;      
    AudioSource effect2Source;


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
        effect1Source = gameObject.AddComponent<AudioSource>();
        effect2Source = gameObject.AddComponent<AudioSource>();
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
        Instance.effect1Source.clip = Instance.winClip;
        Instance.effect1Source.Play();
    }

    //玩家死亡播放音效
    public void PlayerDeathAudio()
    {
        Instance.effect1Source.clip = Instance.deathClip;
        Instance.effect1Source.Play();
    }
    //点击卡牌音效
    public void ClickCardAudio()
    {
        Instance.effect1Source.clip = Instance.clickCardClip;
        Instance.effect1Source.Play();
    }

    //受伤音效
    public void HurtEffectAudio()
    {
        Instance.effect2Source.clip = Instance.hurtEffectClip;
        Instance.effect2Source.Play();
    }

    //受伤声音/呻吟
    public void HurtVoiceAudio()
    {
        Instance.effect1Source.clip = Instance.hurtVoiceClip;
        Instance.effect1Source.Play();
    }

    //获得护甲值的音效
    public void ArmorAudio()
    {
        Instance.effect2Source.clip = Instance.armorClip;
        Instance.effect2Source.Play();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

/// <summary>
/// ����������
/// </summary>
public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("BGM")]
    public AudioClip startBGMClip;  //��ʼ��Ϸʱ��bgm
    public AudioClip fightBGMClip;  //����ս��ʱ��bgm

    [Header("��Ч")]
    public AudioClip deathClip;     //������Ч
    public AudioClip winClip;       //ʤ����Ч
    public AudioClip loseClip;      //ʧ����Ч
    public AudioClip hurtEffectClip; //�ܻ���Ч
    public AudioClip hurtVoiceClip; //�������������Ч
    public AudioClip clickCardClip; //���������Ч
    public AudioClip armorClip;     //��û���ֵ����Ч

    AudioSource bgmSource;
    AudioSource effect1Source;      
    AudioSource effect2Source;


    private void Awake()
    {
        if (Instance != null)                    //��ֹAudioManager�����������ظ����ɣ���������Խ��Խ��
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

    //��ʼ��Ϸʱ����bgm
    public void StartLevelAudio()
    {
        Instance.bgmSource.clip = Instance.startBGMClip;
        Instance.bgmSource.loop = true;
        Instance.bgmSource.Play();
    }

    //ս��ʱ����bgm
    public void FightingAudio()
    {
        Instance.bgmSource.Stop();
        Instance.bgmSource.clip = Instance.fightBGMClip;
        Instance.bgmSource.loop = true;
        Instance.bgmSource.Play();
    }

    //���ʤ��������Ч
    public void PlayerWonAudio()
    {
        Instance.effect1Source.clip = Instance.winClip;
        Instance.effect1Source.Play();
    }

    //�������������Ч
    public void PlayerDeathAudio()
    {
        Instance.effect1Source.clip = Instance.deathClip;
        Instance.effect1Source.Play();
    }
    //���������Ч
    public void ClickCardAudio()
    {
        Instance.effect1Source.clip = Instance.clickCardClip;
        Instance.effect1Source.Play();
    }

    //������Ч
    public void HurtEffectAudio()
    {
        Instance.effect2Source.clip = Instance.hurtEffectClip;
        Instance.effect2Source.Play();
    }

    //��������/����
    public void HurtVoiceAudio()
    {
        Instance.effect1Source.clip = Instance.hurtVoiceClip;
        Instance.effect1Source.Play();
    }

    //��û���ֵ����Ч
    public void ArmorAudio()
    {
        Instance.effect2Source.clip = Instance.armorClip;
        Instance.effect2Source.Play();
    }
}

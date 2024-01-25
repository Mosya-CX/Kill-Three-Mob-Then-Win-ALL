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
    AudioSource attackSource;      
    AudioSource hurtSource;
    AudioSource fightingSource;


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
        attackSource = gameObject.AddComponent<AudioSource>();
        hurtSource = gameObject.AddComponent<AudioSource>();
        fightingSource = gameObject.AddComponent<AudioSource>();

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
        Instance.fightingSource.clip = Instance.winClip;
        Instance.fightingSource.Play();
    }

    //�������������Ч
    public void PlayerDeathAudio()
    {
        Instance.fightingSource.clip = Instance.deathClip;
        Instance.fightingSource.Play();
    }
    //���������Ч
    public void ClickCardAudio()
    {
        Instance.fightingSource.clip = Instance.clickCardClip;
        Instance.fightingSource.Play();
    }

    //������Ч
    public void AttackAudio()
    {
        Instance.attackSource.clip = Instance.hurtEffectClip;
        Instance.attackSource.Play();
    }

    //��������/����
    public void HurtVoiceAudio()
    {
        Instance.hurtSource.clip = Instance.hurtVoiceClip;
        Instance.hurtSource.Play();
    }

    //��û���ֵ����Ч
    public void ArmorAudio()
    {
        Instance.fightingSource.clip = Instance.armorClip;
        Instance.fightingSource.Play();
    }

    // �ر�������Ч
    public void CloseBGM()
    {
        Instance.bgmSource.Stop();
        Instance.fightingSource.Stop();
        Instance.hurtSource.Stop();
        Instance.attackSource.Stop();
    }
}

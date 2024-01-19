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
    public AudioClip playerHurtClip; //���������Ч
    public AudioClip enemyHurtClip; //����������Ч
    public AudioClip clickCardClip; //���������Ч
    public AudioClip armorClip;     //��û���ֵ����Ч

    AudioSource bgmSource;
    AudioSource effectSource;


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
        effectSource = gameObject.AddComponent<AudioSource>();
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
        Instance.effectSource.clip = Instance.winClip;
        Instance.effectSource.Play();
    }

    //�������������Ч
    public void PlayerDeathAudio()
    {
        Instance.effectSource.clip = Instance.deathClip;
        Instance.effectSource.Play();
    }

    //������˲�����Ч
    public void PlayerHurtAudio()
    {
        Instance.effectSource.clip = Instance.playerHurtClip;
        Instance.effectSource.Play();
    }

    //�������˲�����Ч
    public void EnemyHurtAudio()
    {
        Instance.effectSource.clip = Instance.enemyHurtClip;
        Instance.effectSource.Play();
    }

    //���������Ч
    public void ClickCardAudio()
    {
        Instance.effectSource.clip = Instance.clickCardClip;
        Instance.effectSource.Play();
    }

    //��û���ֵ����Ч
    public void ArmorAudio()
    {
        Instance.effectSource.clip = Instance.armorClip;
        Instance.effectSource.Play();
    }
}

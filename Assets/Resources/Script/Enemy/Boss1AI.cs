﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Boss1AI : MonoBehaviour
{
    // ������ʽ
    public int attackMode;
    // ����˳��
    public int attackOrder;
    // ����Ҷ���
    public Player player;
    // ��û���������
    public int baseDamage;
    public Enemy enemy;
    //BOSS����һ���غϹ���
    public int nextMove;
    // 获得animator
    public Animator animator;

    void Start()
    {
        nextMove = Random.Range(1, 3);
        attackMode = 1;
        attackOrder = 1;
        player = GameManager.Instance.player.GetComponent<Player>();
        baseDamage = gameObject.GetComponent<Enemy>().baseDamage;
        enemy = gameObject.GetComponent<Enemy>();
        animator = gameObject.GetComponent<Animator>();
    }

    // �����ж�
    public void Move()
    {
        if (attackOrder == 1)
        {
            if (nextMove == 1)
            {
                // animator.SetTrigger("Attack");
                Attack();
            }
            else
            {
                // animator.SetTrigger("Defend");
                Defend();
            }
            attackOrder++;
        }
        else if (attackOrder == 2)
        {
            if (nextMove == 1)
            {
                // animator.SetTrigger("Attack");
                Attack();
            }
            else
            {
                // animator.SetTrigger("Defend");
                Defend();
            }
            attackOrder++;
        }
        else if (attackOrder == 3)
        {
            if (nextMove == 1)
            {
                // animator.SetTrigger("Attack");
                Attack();
            }
            else
            {
                // animator.SetTrigger("Defend");
                Defend();
            }
            enemy.nextType = ActionType.Skill;
            attackOrder++;

        }
        if(attackOrder == 4)
        {
            // animator.SetTrigger("Skill");

            Skill();
            attackOrder = 1;
        }
        nextMove = Random.Range(1, 3);
        if (attackOrder != 4)
        {
            switch (nextMove)
            {
                case 1:
                    enemy.nextType = ActionType.Attack;   
                    break;
                case 2:
                    enemy.nextType = ActionType.Defend;
                    break;
            }
        }
        
    }

    void Attack()
    {
        AudioManager.Instance.AttackAudio();
        AudioManager.Instance.HurtVoiceAudio();
        int attackCount = 5;
        enemy.nextType = ActionType.Attack;
        // 生成攻击特效
        // enemy.AttackEffeck();
        while (attackCount > 0)
        {
            // 生成伤害数字物体 
            //GameObject obj = GameObject.Instantiate(Resources.Load("Prefab/Item/DamageNum")) as GameObject;
            //obj.transform.position = new Vector2(Random.Range(), Random.Range());// 在某个区域内随机生成位置
            //obj.GetComponent<TMP_Text>().text = (-baseDamage).ToString();
            if (player.Shield >= baseDamage)
            {
                player.Shield -= baseDamage;
            }
            else if (player.Shield < baseDamage && player.Shield > 0)
            {
                player.curHP -= (baseDamage - player.Shield);
                player.Shield = 0;
            }
            else
            {
                player.curHP -= baseDamage;
            }
            attackCount--;
        }
    }

    void Defend()
    {
        AudioManager.Instance.ArmorAudio();
        gameObject.GetComponent<Enemy>().Shield += 12;
    }

    void Skill()
    {
        baseDamage++;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss4AI : MonoBehaviour
{
    // 攻击方式
    public int attackMode;
    // 攻击顺序
    public int attackOrder;
    // 绑定玩家对象
    public Player player;
    // 获得基础攻击力
    public int baseDamage;
    public Enemy enemy;
    //BOSS的下一个回合攻击
    public int nextMove;

    void Start()
    {
        nextMove = Random.Range(1, 4);
        attackMode = 1;
        player = GameManager.Instance.player;
        baseDamage = gameObject.GetComponent<Enemy>().baseDamage;
        enemy = GetComponent<Enemy>();
    }

    // 敌人行动
    public void Move()
    {
        switch(nextMove)
        {
            case 1:
                Action1();
                break;
            case 2:
                Action2();
                break;
            case 3:
                Action3();
                break;
        }
    }

    public void Action1()
    {
        //加盾
        enemy.Shield += 10;
        //往洗牌区玩家加牌
    }

    public void Action2()
    {
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
    }


    public void Action3()
    {
        BuffManager.Instance.enemyBuffList.Clear();//移除负面BUFF
        if (player.Shield >= 8)
        {
            player.Shield -= 8;
        }   //对玩家造成伤害
        else if (player.Shield < 8 && player.Shield > 0)
        {
            player.curHP -= (8 - player.Shield);
            player.Shield = 0;
        }
        else
        {
            player.curHP -= 8;
        }

    }
}

using OfficeOpenXml.FormulaParsing.Excel.Functions.Logical;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager
{
    public static EnemyManager Instance = new EnemyManager();

    // 加载敌人预制体
    public void LoadMob(int id)
    {
        // 获得敌人信息
        Dictionary<string, string> enemyInfo = GameConfigManager.Instance.getEnemyById(id.ToString());
        Vector2 enemyPos = new Vector2(5, 0.8f);//敌人位置，尚未确定
        // 生成敌人
        GameObject obj = GameObject.Instantiate(Resources.Load(enemyInfo["PrefabPath"])) as GameObject;
        obj.transform.position = enemyPos;
        // 绑定敌人
        GameManager.Instance.Enemy = obj;
        // 设置数值
        Enemy enemy = obj.GetComponent<Enemy>();
        if (enemy == null )
        {
            enemy = obj.AddComponent<Enemy>();
        }
        enemy.maxHP = int.Parse(enemyInfo["HP"]);
        enemy.id = id;
    }

    // 移除敌人
    public void RemoveEnemy()
    {
        GameManager.Instance.Enemy = null;
    }
}

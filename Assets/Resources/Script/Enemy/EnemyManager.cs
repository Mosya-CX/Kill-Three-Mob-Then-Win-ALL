using OfficeOpenXml.FormulaParsing.Excel.Functions.Logical;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager
{
    public static EnemyManager Instance = new EnemyManager();

    // 加载敌人预制体
    public void LoadMob(string id)
    {
        // 获得敌人信息
        Dictionary<string, string> enemyInfo = GameConfigManager.Instance.getEnemyById(id);
        Vector2 enemyPos = new Vector2(5, 0.8f);//敌人位置，尚未确定
        // 生成敌人
        GameObject obj = GameObject.Instantiate(Resources.Load(enemyInfo["PrefabPath"])) as GameObject;
        obj.transform.position = enemyPos;
        
        // 设置数值
        Enemy enemy = obj.GetComponent<Enemy>();
        if (enemy == null )
        {
            enemy = obj.AddComponent<Enemy>();
        }
        enemy.maxHP = int.Parse(enemyInfo["HP"]);
        enemy.baseDamage = int.Parse(enemyInfo["BaseDamage"]);
        enemy.name = enemyInfo["Name"];

        // 绑定敌人
        GameManager.Instance.enemy = enemy;
    }

    

}

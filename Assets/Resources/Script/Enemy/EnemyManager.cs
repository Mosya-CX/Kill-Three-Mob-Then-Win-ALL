using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager
{
    public static EnemyManager Instance = new EnemyManager();

    public void LoadMob(int id)
    {
        // ��õ�����Ϣ
        Dictionary<string, string> enemyInfo = GameConfigManager.Instance.getEnemyById(id.ToString());
        Vector2 enemyPos = Vector2.zero;//����λ�ã���δȷ��
        GameObject obj = GameObject.Instantiate(Resources.Load(enemyInfo["PrefabPath"])) as GameObject;
        obj.transform.position = enemyPos;
        Enemy enemy = obj.GetComponent<Enemy>();
        if (enemy == null )
        {
            enemy = obj.AddComponent<Enemy>();
        }
        enemy.HP = int.Parse(enemyInfo["HP"]);
    }
}

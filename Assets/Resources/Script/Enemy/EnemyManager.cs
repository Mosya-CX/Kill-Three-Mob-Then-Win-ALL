using OfficeOpenXml;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Logical;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager
{
    public static EnemyManager Instance = new EnemyManager();

    // ���ص���Ԥ����
    public void LoadMob(string id)
    {
        // ��õ�����Ϣ
        Dictionary<string, string> enemyInfo = GameConfigManager.Instance.getEnemyById(id);
        Vector2 enemyPos = new Vector2(5, 0);//����λ�ã���δȷ��
        // ���ɵ���
        GameObject obj = GameObject.Instantiate(Resources.Load(enemyInfo["PrefabPath"])) as GameObject;
        obj.transform.position = enemyPos;
        
        // ������ֵ
        Enemy enemy = obj.GetComponent<Enemy>();
        if (enemy == null )
        {
            enemy = obj.AddComponent<Enemy>();
        }
        enemy.maxHP = int.Parse(enemyInfo["HP"]);
        enemy.baseDamage = int.Parse(enemyInfo["BaseDamage"]);
        enemy.name = enemyInfo["Name"];
        if (GameManager.Instance == null )
        {
            Debug.Log("6666");
        }
        // �󶨵���
        GameManager.Instance.enemy = enemy;
        BuffManager.Instance.enemyBuffList = enemy.buffList;
        BuffManager.Instance.enemyData = enemy;

    }

    

}
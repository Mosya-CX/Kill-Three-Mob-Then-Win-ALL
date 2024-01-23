using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

// ���������
// �洢�����Ϣ
public class Player : RoleBase
{
    public int currentFee;
    public int totalFee = 4;
    public TMP_Text FeeText;// �󶨷�����ʾui
    public GameObject Enemy;
    public int cardCount=6;   //���ÿ�غϵ�������
    public int finalDemage;// �����ɵ������˺�ֵ�洢����

    private void Start()
    {
        Init();

    }

    private void Update()
    {
        
        onUpdate();
        FeeText.text = currentFee + "/" + totalFee;
    }


    // ����˲����Ч
    public void AttackEffeck()
    {
        GameObject obj = GameObject.Instantiate(Resources.Load("Prefab/Item/AttackEffeck")) as GameObject;
        obj.transform.SetParent(GameObject.Find("UI").transform, false);
        obj.GetComponent<RectTransform>().anchoredPosition = new Vector2(500, 100);
    }

    // ����������
    public void LockInput()
    {
        // ���������  
        Cursor.lockState = CursorLockMode.Locked;
        // ���������  
        Cursor.visible = false;
    }
    // ����������
    public void UnlockInput()
    {
        // ���������  
        Cursor.lockState = CursorLockMode.None;
        // ��ʾ�����  
        Cursor.visible = true;
    }
}

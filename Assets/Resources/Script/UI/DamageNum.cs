using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageNum : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // �ӳ�ɾ��
        Destroy(gameObject, 3);
    }

    // Update is called once per frame
    void Update()
    {
        // �ϸ�Ч��
        Vector2 pos = gameObject.GetComponent<RectTransform>().anchoredPosition;
        pos.y += Time.deltaTime * 30;
        gameObject.GetComponent<RectTransform>().anchoredPosition = pos;
    }
}

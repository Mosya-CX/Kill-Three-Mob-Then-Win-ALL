using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackMoment : MonoBehaviour
{
    public static AttackMoment Instance = new AttackMoment();

    public bool isShake;// ÅÐ¶ÏÆÁÄ»ÊÇ·ñ¶¶¶¯

    // ´ò»÷Í£¶Ù
    public void Hit(int duration)
    {
        StartCoroutine(Pause(duration));
    }
    // ÆÁÄ»¶¶¶¯
    public void camShake(float duration, float strength)
    {
        if (!isShake)
        {
            StartCoroutine(Shake(duration, strength));
        }
    }

    // Ê±Í£
    IEnumerator Pause(int duration)
    {
        float pauseTime = duration / 60f;
        Time.timeScale = 0.1f;
        yield return new WaitForSecondsRealtime(pauseTime);
        Time.timeScale = 1f;
    }
    // ÆÁÄ»¶¶¶¯
    IEnumerator Shake(float duration, float strength)
    {
        isShake = true;
        Transform camera = Camera.main.transform;
        Vector3 startPos = camera.position;
        
        while (duration > 0)
        {
            camera.position = Random.insideUnitSphere * strength + startPos;
            duration -= Time.deltaTime;
            yield return null;
        }
        camera.position = startPos;
        isShake = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearingPlatform : MonoBehaviour
{
    public GameObject a;
    public GameObject b;
    public GameObject c;

    public float disappearTime = 2f; // 플랫폼이 사라지기까지의 시간
    public float respawnTime = 2f; // 플랫폼이 다시 나타나기까지의 시간

    private void Start()
    {
        StartCoroutine(PlatformCycle());
    }

    private IEnumerator PlatformCycle()
    {
        while (true) // 싸이클 무한 반복
        {
            yield return new WaitForSeconds(disappearTime); 
            Debug.Log("Platform disappearing");
            a.SetActive(false);// 각 플랫폼 비활성화
            b.SetActive(false);
            c.SetActive(false);


            yield return new WaitForSeconds(respawnTime);
            Debug.Log("Platform respawning");
            a.SetActive(true);// 각 플랫폼 활성화
            b.SetActive(true);
            c.SetActive(true);
        }
    }
}
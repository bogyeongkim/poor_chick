using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogMg : MonoBehaviour
{
    public GameObject fogPlane;  // 안개 plane 오브젝트

    void Start()
    {
        // 시작 시 안개 plane 비활성화
        if (fogPlane != null)
        {
            fogPlane.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            fogPlane.SetActive(true);  // 플레이어가 닿으면 활성화
        }
    }
}
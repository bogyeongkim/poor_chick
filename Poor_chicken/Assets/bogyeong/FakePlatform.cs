using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakePlatform : MonoBehaviour
{
    private MeshCollider meshCollider;
    private bool isReal = false; // 기본 설정 : 물리적 충돌 비활성화

    public void SetAsReal()
    {
        meshCollider = GetComponent<MeshCollider>();
        isReal = true; // 진짜 플랫폼
        meshCollider.isTrigger = false; // 트리거 해제, 물리적 충돌 활성화
        Debug.Log(gameObject.name + " is Real!");
    }

    public void SetAsFake()
    {
        meshCollider = GetComponent<MeshCollider>();
        isReal = false; // 가짜 플랫폼
        Debug.Log(gameObject.name + " is Fake!");
    }
}

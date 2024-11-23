using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakePlatform : MonoBehaviour
{
    private MeshCollider meshCollider;
    private bool isReal = false; // 발판의 상태 (진짜인지 여부)

    void Start()
    {
        meshCollider = GetComponent<MeshCollider>();
        meshCollider.isTrigger = false;
    }

    public void SetAsReal()
    {
        isReal = true; // 진짜 발판 설정
        Debug.Log(gameObject.name + " is Real!");
    }

    public void SetAsFake()
    {
        isReal = false; // 가짜 발판 설정
        meshCollider.isTrigger = true;
        Debug.Log(gameObject.name + " is Fake!");
    }
}

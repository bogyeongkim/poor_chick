using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakePlatform : MonoBehaviour
{
    private MeshCollider meshCollider;
    private bool isReal = false; // ������ ���� (��¥���� ����)

    void Start()
    {
        //meshCollider = GetComponent<MeshCollider>();
        //meshCollider.isTrigger = true;
    }

    public void SetAsReal()
    {
        meshCollider = GetComponent<MeshCollider>();
        isReal = true; // ��¥ ���� ����
        meshCollider.isTrigger = false;
        Debug.Log(gameObject.name + " is Real!");
    }

    public void SetAsFake()
    {
        meshCollider = GetComponent<MeshCollider>();
        isReal = false; // ��¥ ���� ����
        //meshCollider.isTrigger = true;
        Debug.Log(gameObject.name + " is Fake!");
    }
}

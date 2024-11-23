using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakePlatform : MonoBehaviour
{
    private MeshCollider meshCollider;
    private bool isReal = false; // ������ ���� (��¥���� ����)

    void Start()
    {
        meshCollider = GetComponent<MeshCollider>();
        meshCollider.isTrigger = false;
    }

    public void SetAsReal()
    {
        isReal = true; // ��¥ ���� ����
        Debug.Log(gameObject.name + " is Real!");
    }

    public void SetAsFake()
    {
        isReal = false; // ��¥ ���� ����
        meshCollider.isTrigger = true;
        Debug.Log(gameObject.name + " is Fake!");
    }
}

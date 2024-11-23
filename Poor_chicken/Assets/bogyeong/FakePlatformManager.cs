using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakePlatformManager : MonoBehaviour
{
    public GameObject[] platforms; // ���� �迭
    private int realPlatformIndex; // ��¥ ������ �ε���

    void Start()
    {
        // ���� �� �ϳ��� ��¥ �������� ���� ����
        realPlatformIndex = Random.Range(0, platforms.Length);

        // ���� ����
        for (int i = 0; i < platforms.Length; i++)
        {
            if (i == realPlatformIndex)
            {
                platforms[i].GetComponent<FakePlatform>().SetAsReal(); // ��¥ ���� ����
            }
            else
            {
                platforms[i].GetComponent<FakePlatform>().SetAsFake(); // ��¥ ���� ����
            }
        }
    }
}

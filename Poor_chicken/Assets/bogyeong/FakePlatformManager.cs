using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakePlatformManager : MonoBehaviour
{
    public GameObject[] platforms; // 발판 배열
    private int realPlatformIndex; // 진짜 발판의 인덱스

    void Start()
    {
        // 발판 중 하나를 진짜 발판으로 랜덤 선택
        realPlatformIndex = Random.Range(0, platforms.Length);

        // 발판 설정
        for (int i = 0; i < platforms.Length; i++)
        {
            if (i == realPlatformIndex)
            {
                platforms[i].GetComponent<FakePlatform>().SetAsReal(); // 진짜 발판 설정
            }
            else
            {
                platforms[i].GetComponent<FakePlatform>().SetAsFake(); // 가짜 발판 설정
            }
        }
    }
}

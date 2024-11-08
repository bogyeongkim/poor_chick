using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingplatform2 : MonoBehaviour
{
    public float speed = 2.0f; // 플랫폼의 이동 속도
    public float distance = 5.0f; // 이동할 거리
    public int move = 0;

    private Vector3 startPosition;
    private Vector3 endPosition;
    private float journeyLength;
    private float startTime;

    void Start()
    {
        startPosition = transform.position;

        if (move == 0)
        {
            endPosition = startPosition + new Vector3(distance, 0, 0);
        }
        else if (move == 1)
        {
            endPosition = startPosition - new Vector3(distance, 0, 0);
        }
        else if (move == 2)
        {
            endPosition = startPosition + new Vector3(0, distance, 0);
        }
        else
        {
            endPosition = startPosition - new Vector3(0, distance, 0);
        }

        journeyLength = Vector3.Distance(startPosition, endPosition);
        startTime = Time.time;
    }

    void Update()
    {
        float distCovered = (Time.time - startTime) * speed;
        float fractionOfJourney = distCovered / journeyLength;

        if (fractionOfJourney >= 1)
        {
            // 방향 전환
            Vector3 temp = startPosition;
            startPosition = endPosition;
            endPosition = temp;
            startTime = Time.time; // 시간 초기화
        }

        transform.position = Vector3.Lerp(startPosition, endPosition, fractionOfJourney);
    }

    void OnTriggerEnter(Collider other)
    {

        UnityEngine.Debug.Log("trigger!!");


        other.transform.parent = transform; // 객체의 부모를 발판으로 설정
    }

    void OnTriggerExit(Collider other)
    {
    if (other.CompareTag("Player"))
    {

        other.transform.parent = null; // 부모 관계 해제
    }
}
}
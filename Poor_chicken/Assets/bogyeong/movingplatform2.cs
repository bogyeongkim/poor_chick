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
        else if (move == 3)
        {
            endPosition = startPosition - new Vector3(0, distance, 0);
        }
        else if (move == 4)
        {
            endPosition = startPosition - new Vector3(0, 0, distance);
        }
        else if (move == 5)
        {
            endPosition = startPosition + new Vector3(0, 0, distance);
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
            // 방향 변경하여 왔다갔다 이동하도록
            transform.position = endPosition;  
                                               
            Vector3 temp = startPosition;
            startPosition = endPosition;
            endPosition = temp;
            startTime = Time.time;
        }
        else
        {
            // 선형보간 이용 -> 부드러운 플랫폼 움직임
            transform.position = Vector3.Lerp(startPosition, endPosition, fractionOfJourney);
        }
    }

    void OnTriggerEnter(Collider other)
    {

        UnityEngine.Debug.Log("trigger!!");


        other.transform.parent = transform; // 플랫폼을 부모로 -> 플랫폼 위에서 따라 움직이도록
    }

    void OnTriggerExit(Collider other)
    {
    if (other.CompareTag("Player"))
        {

            other.transform.parent = null; // 부모 관계 해제
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objmove : MonoBehaviour
{
    public float speed = 2.0f; // �÷����� �̵� �ӵ�
    public float distance = 5.0f; // �̵��� �Ÿ�
    private Vector3 startPosition;
    private Vector3 endPosition;
    private float journeyLength;
    private float startTime;

    void Start()
    {
        startPosition = transform.position;
        endPosition = startPosition + new Vector3(distance, 0, 0);
        journeyLength = Vector3.Distance(startPosition, endPosition);
        startTime = Time.time;
    }

    void Update()
    {
        float distCovered = (Time.time - startTime) * speed;
        float fractionOfJourney = distCovered / journeyLength;

        if (fractionOfJourney >= 1)
        {
            // ���� ��ȯ
            Vector3 temp = startPosition;
            startPosition = endPosition;
            endPosition = temp;
            startTime = Time.time; // �ð� �ʱ�ȭ
        }

        transform.position = Vector3.Lerp(startPosition, endPosition, fractionOfJourney);
    }
}


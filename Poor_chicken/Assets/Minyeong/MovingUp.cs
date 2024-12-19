using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingUp : MonoBehaviour
{
    public float speed = 2.0f; // �÷����� �̵� �ӵ�
    public float distance = 5.0f; // �̵��� �Ÿ�
    public bool moveUp = true; // �̵� ���� (true: ������, false: ����)

    private Vector3 startPosition;
    private Vector3 endPosition;
    private float journeyLength;
    private float startTime;

    void Start()
    {
        startPosition = transform.position;

        // �̵� ���⿡ ���� �� ��ġ ����
        if (moveUp)
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
            transform.position = endPosition;

            Vector3 temp = startPosition;
            startPosition = endPosition;
            endPosition = temp;
            startTime = Time.time; // �ð� �ʱ�ȭ
        }
        else
        {
            transform.position = Vector3.Lerp(startPosition, endPosition, fractionOfJourney);
        }
    }
}

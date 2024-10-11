using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float speed = 2.0f; // �÷����� �̵� �ӵ�
    public float distance = 5.0f; // �̵��� �Ÿ�
    public bool moveRight = true; // �̵� ���� (true: ������, false: ����)

    private Vector3 startPosition;
    private Vector3 endPosition;
    private float journeyLength;
    private float startTime;

    void Start()
    {
        startPosition = transform.position;

        // �̵� ���⿡ ���� �� ��ġ ����
        if (moveRight)
        {
            endPosition = startPosition + new Vector3(distance, 0, 0);
        }
        else
        {
            endPosition = startPosition - new Vector3(distance, 0, 0);
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
            // ���� ��ȯ
            Vector3 temp = startPosition;
            startPosition = endPosition;
            endPosition = temp;
            startTime = Time.time; // �ð� �ʱ�ȭ
        }

        transform.position = Vector3.Lerp(startPosition, endPosition, fractionOfJourney);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCloud : MonoBehaviour
{
    public float speed = 0.5f; // �̵� �ӵ�
    public float startPositionX = -500f; // ���� ��ġ (UI ĵ���� ��ǥ)
    public float endPositionX = 500f;   // �� ��ġ (UI ĵ���� ��ǥ)

    private RectTransform rectTransform;

    void Start()
    {
        // RectTransform ��������
        rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        // ���� �̵�
        rectTransform.anchoredPosition += Vector2.right * speed * Time.deltaTime;

        // �� ��ġ�� �Ѿ�� ���� ��ġ�� �̵�
        if (rectTransform.anchoredPosition.x > endPositionX)
        {
            rectTransform.anchoredPosition = new Vector2(startPositionX, rectTransform.anchoredPosition.y);
        }
    }
}
/*
public class MovingCloud : MonoBehaviour
{
    public float speed = 0.5f;
    public float startPositionX = -22f;
    public float endPositionX = 21f;

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        if (transform.position.x > endPositionX)
        {
            transform.position = new Vector2(startPositionX, transform.position.y);
        }
    }
}
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCloud : MonoBehaviour
{
    public float speed = 0.5f; // 이동 속도
    public float startPositionX = -500f; // 시작 위치 (UI 캔버스 좌표)
    public float endPositionX = 500f;   // 끝 위치 (UI 캔버스 좌표)

    private RectTransform rectTransform;

    void Start()
    {
        // RectTransform 가져오기
        rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        // 구름 이동
        rectTransform.anchoredPosition += Vector2.right * speed * Time.deltaTime;

        // 끝 위치를 넘어서면 시작 위치로 이동
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
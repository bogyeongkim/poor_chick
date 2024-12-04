using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Title : MonoBehaviour
{
    public float delayTime = 2.0f; // 오브젝트가 나타나기 전 지연 시간 (초)

    private Image uiImage; // UI Image 컴포넌트

    void Start()
    {
        // Image 컴포넌트 가져오기
        uiImage = GetComponent<Image>();

        // 시작 시 오브젝트를 투명하게 설정
        Color color = uiImage.color;
        color.a = 0f;
        uiImage.color = color;

        // 지연 후 알파값 변경 코루틴 실행
        StartCoroutine(StartBlinkAfterDelay());
    }

    IEnumerator StartBlinkAfterDelay()
    {
        // 지정된 시간(delayTime)만큼 대기
        yield return new WaitForSeconds(delayTime);

        // 알파값을 1로 변경하여 이미지가 보이게 설정
        Color color = uiImage.color;
        color.a = 1.0f;
        uiImage.color = color;
    }
}

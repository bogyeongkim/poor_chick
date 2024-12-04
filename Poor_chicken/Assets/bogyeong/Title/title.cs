using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Title : MonoBehaviour
{
    public float delayTime = 2.0f; // ������Ʈ�� ��Ÿ���� �� ���� �ð� (��)

    private Image uiImage; // UI Image ������Ʈ

    void Start()
    {
        // Image ������Ʈ ��������
        uiImage = GetComponent<Image>();

        // ���� �� ������Ʈ�� �����ϰ� ����
        Color color = uiImage.color;
        color.a = 0f;
        uiImage.color = color;

        // ���� �� ���İ� ���� �ڷ�ƾ ����
        StartCoroutine(StartBlinkAfterDelay());
    }

    IEnumerator StartBlinkAfterDelay()
    {
        // ������ �ð�(delayTime)��ŭ ���
        yield return new WaitForSeconds(delayTime);

        // ���İ��� 1�� �����Ͽ� �̹����� ���̰� ����
        Color color = uiImage.color;
        color.a = 1.0f;
        uiImage.color = color;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Net.Mime.MediaTypeNames;
using UnityEngine.UI;

public class ImageBlink : MonoBehaviour
{
    public float blinkSpeed = 1.0f; // �����̴� �ӵ� ����
    public float minAlpha = 0.0f;   // �ּ� ���� ��
    public float maxAlpha = 1.0f;   // �ִ� ���� ��
    public float delayTime = 2.0f;  // ������Ʈ�� ��Ÿ���� �� ���� �ð� (��)

    private UnityEngine.UI.Image uiImage; // UI Image ������Ʈ
    private bool fadingOut = false;

    void Start()
    {
        // Image ������Ʈ ��������
        uiImage = GetComponent<UnityEngine.UI.Image>();

        // ���� �� ������Ʈ�� �����ϰ� ����
        Color color = uiImage.color;
        color.a = 0f;
        uiImage.color = color;

        // �����̴� ȿ�� ���� �ڷ�ƾ ȣ��
        StartCoroutine(StartBlinkAfterDelay());
    }

    IEnumerator StartBlinkAfterDelay()
    {
        // ������ �ð�(delayTime)��ŭ ���
        yield return new WaitForSeconds(delayTime);

        // ���� �����̱� ����
        while (true)
        {
            yield return null;
            UpdateBlink();
        }
    }

    void UpdateBlink()
    {
        Color color = uiImage.color;

        // alpha ���� ���� �Ǵ� ������Ű�� ������ ó��
        if (fadingOut)
        {
            color.a -= blinkSpeed * Time.deltaTime;
            if (color.a <= minAlpha)
            {
                color.a = minAlpha;
                fadingOut = false;
            }
        }
        else
        {
            color.a += blinkSpeed * Time.deltaTime;
            if (color.a >= maxAlpha)
            {
                color.a = maxAlpha;
                fadingOut = true;
            }
        }

        uiImage.color = color; // ����� color �� ����
    }
}

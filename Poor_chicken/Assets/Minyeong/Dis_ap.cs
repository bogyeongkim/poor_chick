using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dis_ap : MonoBehaviour
{
    public GameObject a;
    public GameObject b;
    public GameObject c;

    public float disappearTime = 2f; // �÷����� ������������ �ð�
    public float respawnTime = 2f; // �÷����� �ٽ� ��Ÿ��������� �ð�

    private void Start()
    {
        StartCoroutine(PlatformCycle());
    }

    private IEnumerator PlatformCycle()
    {
        while (true) // ���� �ݺ�
        {
            yield return new WaitForSeconds(disappearTime); // ���������� ���
            Debug.Log("Platform disappearing");
            a.SetActive(false); // �÷��� ��Ȱ��ȭ
            b.SetActive(false);
            c.SetActive(false);


            yield return new WaitForSeconds(respawnTime);
            Debug.Log("Platform respawning");
            a.SetActive(true);
            b.SetActive(true);
            c.SetActive(true);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class jumpingplatform : MonoBehaviour
{
    public float jumpHeightBoost = 2.2f;  // �߰� ���� ����
    private float originalJumpHeight;     // ���� ���� ����

    private void OnTriggerEnter(Collider other)
    {
        UnityEngine.Debug.Log("frog");
        // �÷��̾�� �浹�ߴ���
        if (other.CompareTag("Player"))
        {
            UnityEngine.Debug.Log("frog");

            ThirdPersonController thirdPersonController = other.GetComponent<ThirdPersonController>();

            if (thirdPersonController != null)
            {
                // ���ο� ���� ���� ����
                originalJumpHeight = thirdPersonController.JumpHeight;
                thirdPersonController.JumpHeight *= jumpHeightBoost;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //�÷������� ��������
        if (other.CompareTag("Player"))
        {
            ThirdPersonController thirdPersonController = other.GetComponent<ThirdPersonController>();

            if (thirdPersonController != null)
            {
                // ���� ���̸� ���� ������ ����
                thirdPersonController.JumpHeight = originalJumpHeight;
            }
        }
    }
}
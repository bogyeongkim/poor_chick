using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class jumpingplatform : MonoBehaviour
{
    public float jumpHeightBoost = 2.2f;  // 추가 점프 높이
    private float originalJumpHeight;     // 원래 점프 높이

    private void OnTriggerEnter(Collider other)
    {
        UnityEngine.Debug.Log("frog");
        // 플레이어와 충돌했는지
        if (other.CompareTag("Player"))
        {
            UnityEngine.Debug.Log("frog");

            ThirdPersonController thirdPersonController = other.GetComponent<ThirdPersonController>();

            if (thirdPersonController != null)
            {
                // 새로운 점프 높이 설정
                originalJumpHeight = thirdPersonController.JumpHeight;
                thirdPersonController.JumpHeight *= jumpHeightBoost;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //플랫폼에서 떨어지면
        if (other.CompareTag("Player"))
        {
            ThirdPersonController thirdPersonController = other.GetComponent<ThirdPersonController>();

            if (thirdPersonController != null)
            {
                // 점프 높이를 원래 값으로 복원
                thirdPersonController.JumpHeight = originalJumpHeight;
            }
        }
    }
}
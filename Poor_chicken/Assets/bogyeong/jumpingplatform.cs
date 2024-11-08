using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class jumpingplatform : MonoBehaviour
{
    public float jumpHeightBoost = 2.2f;  // 추가 점프 높이 (예: 2.2배 증가)
    private float originalJumpHeight;     // 원래 점프 높이 저장

    private void OnTriggerEnter(Collider other)
    {
        UnityEngine.Debug.Log("frog");
        // 플레이어와 충돌했는지 확인
        if (other.CompareTag("Player"))
        {
            UnityEngine.Debug.Log("frog");
            // 플레이어의 ThirdPersonController 스크립트를 가져옴
            ThirdPersonController thirdPersonController = other.GetComponent<ThirdPersonController>();

            if (thirdPersonController != null)
            {
                // 원래 점프 높이를 저장하고, 새로운 점프 높이 설정
                originalJumpHeight = thirdPersonController.JumpHeight;
                thirdPersonController.JumpHeight *= jumpHeightBoost;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // 플레이어가 발판에서 떨어지면 원래 점프 높이로 되돌림
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
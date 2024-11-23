using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    private Rigidbody rb; // 오브젝트의 Rigidbody 컴포넌트
    private Vector3 initialPosition; // 초기 위치 저장
    private Quaternion initialRotation; // 초기 회전 저장
    private bool isFalling = false; // 현재 떨어지는 중인지 확인

    void Start()
    {
        // Rigidbody 컴포넌트를 가져옴
        rb = GetComponent<Rigidbody>();

        // Rigidbody의 중력 적용을 비활성화
        rb.useGravity = false;

        // 초기 위치와 회전 저장
        initialPosition = transform.position;
        initialRotation = transform.rotation;
    }

    // 캐릭터가 트리거에 접촉했을 때 호출되는 메서드
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isFalling) // 캐릭터와 접촉했으며 떨어지는 중이 아닐 때
        {
            StartCoroutine(FallAfterDelay());
            Debug.Log("Player stepped on the object!");
        }
    }

    private IEnumerator FallAfterDelay()
    {
        isFalling = true; // 떨어지는 상태로 설정
        yield return new WaitForSeconds(0.1f);

        // Rigidbody 활성화 (떨어짐 시작)
        rb.isKinematic = false;
        rb.useGravity = true;

        Debug.Log("Object is now falling!");

        // 떨어지고 나서 10초 기다렸다가 복원
        yield return new WaitForSeconds(10f);
        ResetPlatform();
    }

    private void ResetPlatform()
    {
        // Rigidbody 상태 초기화
        rb.isKinematic = true;
        rb.useGravity = false;

        // 위치와 회전을 초기 상태로 복원
        transform.position = initialPosition;
        transform.rotation = initialRotation;

        isFalling = false; // 떨어지는 상태 해제
        Debug.Log("Object reset to its original position!");
    }
}

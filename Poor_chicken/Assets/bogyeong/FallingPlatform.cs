using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    private Rigidbody rb; // 오브젝트의 Rigidbody 컴포넌트
    private Vector3 initialPosition; // 초기 위치 저장
    private Quaternion initialRotation; // 초기 회전 저장
    private bool isFalling = false; // 떨어지는 중인지 확인

    void Start()
    {
        // Rigidbody 컴포넌트 가져옴
        rb = GetComponent<Rigidbody>();

        // 중력 비활성화
        rb.useGravity = false;

        // 초기 포지션&로테이션 저장
        initialPosition = transform.position;
        initialRotation = transform.rotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isFalling) // 캐릭터와 접촉&떨어지는 중 아닐 때
        {
            StartCoroutine(FallAfterDelay());
            Debug.Log("Player stepped on the object!");
        }
    }

    private IEnumerator FallAfterDelay()
    {
        isFalling = true; // 떨어지는 상태로 설정
        yield return new WaitForSeconds(0.1f);

        // Rigidbody 활성화 -> 중력 적용 -> 아래로 떨어짐
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

        // 포지션&로테이션 복원
        transform.position = initialPosition;
        transform.rotation = initialRotation;

        isFalling = false; // 떨어지는 상태 해제
        Debug.Log("Object reset to its original position!");
    }
}

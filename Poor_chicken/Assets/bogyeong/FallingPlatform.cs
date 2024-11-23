using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    private Rigidbody rb; // ������Ʈ�� Rigidbody ������Ʈ
    private Vector3 initialPosition; // �ʱ� ��ġ ����
    private Quaternion initialRotation; // �ʱ� ȸ�� ����
    private bool isFalling = false; // ���� �������� ������ Ȯ��

    void Start()
    {
        // Rigidbody ������Ʈ�� ������
        rb = GetComponent<Rigidbody>();

        // Rigidbody�� �߷� ������ ��Ȱ��ȭ
        rb.useGravity = false;

        // �ʱ� ��ġ�� ȸ�� ����
        initialPosition = transform.position;
        initialRotation = transform.rotation;
    }

    // ĳ���Ͱ� Ʈ���ſ� �������� �� ȣ��Ǵ� �޼���
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isFalling) // ĳ���Ϳ� ���������� �������� ���� �ƴ� ��
        {
            StartCoroutine(FallAfterDelay());
            Debug.Log("Player stepped on the object!");
        }
    }

    private IEnumerator FallAfterDelay()
    {
        isFalling = true; // �������� ���·� ����
        yield return new WaitForSeconds(0.1f);

        // Rigidbody Ȱ��ȭ (������ ����)
        rb.isKinematic = false;
        rb.useGravity = true;

        Debug.Log("Object is now falling!");

        // �������� ���� 10�� ��ٷȴٰ� ����
        yield return new WaitForSeconds(10f);
        ResetPlatform();
    }

    private void ResetPlatform()
    {
        // Rigidbody ���� �ʱ�ȭ
        rb.isKinematic = true;
        rb.useGravity = false;

        // ��ġ�� ȸ���� �ʱ� ���·� ����
        transform.position = initialPosition;
        transform.rotation = initialRotation;

        isFalling = false; // �������� ���� ����
        Debug.Log("Object reset to its original position!");
    }
}

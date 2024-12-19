using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingPlatform : MonoBehaviour
{
    public Vector3 rotationAxis = Vector3.forward; // ȸ�� ��(�⺻��:Z��)
    public float rotationSpeed = 50.0f; // ȸ�� �ӵ�(���: �ð����, ����: �ݽð����)

    void Update()
    {
        transform.Rotate(rotationAxis * rotationSpeed * Time.deltaTime);
    }
    void OnTriggerEnter(Collider other)
    {

        UnityEngine.Debug.Log("trigger!!");


        other.transform.parent = transform; 
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            other.transform.parent = null; // �θ� ���� ����
        }
    }

}

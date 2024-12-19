using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingPlatform : MonoBehaviour
{
    public Vector3 rotationAxis = Vector3.forward; // 회전 축(기본값:Z축)
    public float rotationSpeed = 50.0f; // 회전 속도(양수: 시계방향, 음수: 반시계방향)

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

            other.transform.parent = null; // 부모 관계 해제
        }
    }

}

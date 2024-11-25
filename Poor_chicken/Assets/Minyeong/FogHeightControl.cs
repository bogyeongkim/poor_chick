using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogHeightControl : MonoBehaviour
{
    public GameObject fogPlane;              // 안개 plane 오브젝트
    public Transform player;                 // 플레이어 Transform
    public float activationHeight = 10f;     // 안개가 시작되는 높이
    public float fullFogHeight = 14f;        // 안개가 완전히 불투명해지는 높이

    private Material fogMaterial;            // 안개 plane의 Material

    void Start()
    {
        if (fogPlane != null)
        {
            fogMaterial = fogPlane.GetComponent<Renderer>().material;
            SetFogAlpha(0f); // 시작 시 안개 plane을 투명하게 설정
        }
    }

    void Update()
    {
        if (fogPlane != null && player != null)
        {
            float playerHeight = player.position.y;

            // 플레이어 높이가 활성화 범위 안에 있을 때 불투명도를 선형적으로 변경
            if (playerHeight >= activationHeight && playerHeight <= fullFogHeight)
            {
                // 높이에 따라 안개 불투명도를 0~1로 선형 보간
                float t = (playerHeight - activationHeight) / (fullFogHeight - activationHeight);
                SetFogAlpha(t);
            }
            else if (playerHeight > fullFogHeight)
            {
                SetFogAlpha(1f); // 최대 높이 이상에서는 완전히 불투명
            }
            else
            {
                SetFogAlpha(0f); // 최소 높이 이하에서는 완전히 투명
            }
        }
    }

    // 안개의 알파 값을 설정하는 메서드
    void SetFogAlpha(float alpha)
    {
        Color color = fogMaterial.color;
        color.a = alpha;
        fogMaterial.color = color;
    }
}
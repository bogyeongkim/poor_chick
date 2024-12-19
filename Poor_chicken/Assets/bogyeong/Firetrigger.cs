using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firetrigger : MonoBehaviour
{
    ParticleSystem ps;
    List<ParticleSystem.Particle> inside = new List<ParticleSystem.Particle>();

    private void Awake()
    {
        ps = GetComponent<ParticleSystem>();
    }

    private void OnParticleTrigger() // 불꽃 파티클 트리거 -> 게임매니저 연결 후 목숨 감소
    {
        ps.GetTriggerParticles(ParticleSystemTriggerEventType.Inside, inside);

        foreach (var v in inside)
        {
            UnityEngine.Debug.Log("불꽃");
            farm_GameManager gameManager = FindObjectOfType<farm_GameManager>();
            if (gameManager != null)
            {
                gameManager.LoseLife();
            }
            gameObject.SetActive(false);
        }
    }
}

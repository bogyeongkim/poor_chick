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

    private void OnParticleTrigger()
    {
        ps.GetTriggerParticles(ParticleSystemTriggerEventType.Inside, inside);

        foreach (var v in inside)
        {
            UnityEngine.Debug.Log("ºÒ²É");
            farm_GameManager gameManager = FindObjectOfType<farm_GameManager>();
            if (gameManager != null)
            {
                gameManager.LoseLife();
            }
            gameObject.SetActive(false);
        }
    }
}

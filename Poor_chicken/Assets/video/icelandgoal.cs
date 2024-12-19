using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class icelandGoal : MonoBehaviour
{

    public AudioClip soundEffect;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        UnityEngine.Debug.Log("Goal in!");
        audioSource.PlayOneShot(soundEffect);
        StartCoroutine(WaitForAnimation());
    }

    IEnumerator WaitForAnimation()
    {
        yield return new WaitForSeconds(3.0f);


        UnityEngine.Debug.Log("load next scene");
        SceneManager.LoadScene("farm");
    }
}
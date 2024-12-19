using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class reachGoal : MonoBehaviour
{
    public Animator mom;

    public AudioClip[] soundEffect;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        UnityEngine.Debug.Log("Goal in!");
        audioSource.PlayOneShot(soundEffect[0]);
        audioSource.PlayOneShot(soundEffect[1]);
        mom.SetTrigger("idle_4");

        StartCoroutine(WaitForAnimation());
    }

    IEnumerator WaitForAnimation()
    {
        yield return new WaitForSeconds(mom.GetCurrentAnimatorStateInfo(0).length + 4.0f);


        UnityEngine.Debug.Log("load next scene");
        SceneManager.LoadScene("EndVideo");
    }
}

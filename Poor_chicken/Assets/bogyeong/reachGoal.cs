using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class reachGoal : MonoBehaviour
{
    public Animator mom;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        UnityEngine.Debug.Log("Goal in!");

        mom.SetTrigger("idle_4");

        StartCoroutine(WaitForAnimation());
    }

    IEnumerator WaitForAnimation()
    {
        yield return new WaitForSeconds(mom.GetCurrentAnimatorStateInfo(0).length + 1.0f);


        UnityEngine.Debug.Log("load next scene");
        //SceneManager.LoadScene("ending");
    }
}

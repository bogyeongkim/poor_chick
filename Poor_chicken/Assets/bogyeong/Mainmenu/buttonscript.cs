using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonscript : MonoBehaviour
{
    public GameObject howtoplay;

    public void OnStartButtonClick()
    {
        UnityEngine.Debug.Log("startbutton");
        SceneManager.LoadScene("farm");
    }

    public void OnHelpButtonClick()
    {
        UnityEngine.Debug.Log("helpbutton");
        howtoplay.SetActive(true);
    }

    public void OnexitButtonClick()
    {
        UnityEngine.Debug.Log("exitbutton");
        howtoplay.SetActive(false);
    }
}

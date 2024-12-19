using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class buttonscript : MonoBehaviour
{
    public GameObject box;

    public AudioSource music;
    public Button musicOnButton; 
    public Button musicOffButton; 

    public void OnStartButtonClick()
    {
        UnityEngine.Debug.Log("startbutton");
        SceneManager.LoadScene("IntroVideo");
    }

    public void OnHelpButtonClick()
    {
        UnityEngine.Debug.Log("helpbutton");
        box.SetActive(true);
    }

    public void OnexitButtonClick()
    {
        UnityEngine.Debug.Log("exitbutton");
        box.SetActive(false);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("title"); 
    }

    public void Mainmenu()
    {
        SceneManager.LoadScene("Mainmenu");
    }

    public void MusicOn()
    {
        if (music.isPlaying)
        {
            music.Stop();
        }

        musicOffButton.interactable = true;

        musicOnButton.interactable = false;
    }

    public void MusicOff()
    {
        if (music.isPlaying)
        {
            music.Play();
        }

        musicOffButton.interactable = false;

        musicOnButton.interactable = true;
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        // 에디터에서 게임 종료
        EditorApplication.isPlaying = false;
#else
        // 빌드된 게임에서 게임 종료
        Application.Quit();
#endif
    }
}

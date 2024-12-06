using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonscript : MonoBehaviour
{
    public GameObject howtoplay;

    public void OnStartButtonClick()
    {
        UnityEngine.Debug.Log("startbutton");
        SceneManager.LoadScene("IntroVideo");
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

    public void RestartGame()
    {
        // MainMenu 씬으로 전환
        SceneManager.LoadScene("title"); 
    }

    // 게임 종료 함수
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

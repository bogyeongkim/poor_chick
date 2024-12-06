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
        // MainMenu ������ ��ȯ
        SceneManager.LoadScene("title"); 
    }

    // ���� ���� �Լ�
    public void QuitGame()
    {
#if UNITY_EDITOR
        // �����Ϳ��� ���� ����
        EditorApplication.isPlaying = false;
#else
        // ����� ���ӿ��� ���� ����
        Application.Quit();
#endif
    }
}

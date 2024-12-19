using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Setting : MonoBehaviour
{
    public GameObject box; 
    public AudioSource backgroundMusic; 
    private bool isPaused = false; 
    private bool isMusicOn = true;

    void Update()
    {
        // ESC Ű �Է� Ȯ��
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause(); // ESC Ű ������ Pause ���� ��ȯ
        }

        // ���� â�� ���� ���¿����� �߰� �Է� ó��
        if (isPaused)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                QuitGame(); // ���� ����
            }
            else if (Input.GetKeyDown(KeyCode.M))
            {
                LoadMainMenu(); // ���� �޴��� ��ȯ
            }
            else if (Input.GetKeyDown(KeyCode.U))
            {
                ToggleMusic(); // ���� ON/OFF ���
            }
        }
    }

    void TogglePause()
    {
        if (isPaused)
        {
            // ���� �簳
            Time.timeScale = 1f; // ���� �ӵ� ����
            box.SetActive(false); // ���� �ڽ� �����
            isPaused = false;
        }
        else
        {
            // ���� ����
            Time.timeScale = 0f; // ���� ����
            box.SetActive(true); // ���� �ڽ� ǥ��
            isPaused = true;
        }
    }

    void QuitGame()
    {
        Debug.Log("���� ����");
        Application.Quit(); // ���� ����
    }

    void ToggleMusic()
    {
        if (backgroundMusic != null)
        {
            isMusicOn = !isMusicOn;
            backgroundMusic.mute = !isMusicOn;
            Debug.Log(isMusicOn ? "���� ����" : "���� ����");
        }
        else
        {
            Debug.LogWarning("Background Music ������Ʈ�� ������� �ʾҽ��ϴ�.");
        }
    }

    void LoadMainMenu()
    {
        Debug.Log("���� �޴��� �̵�");
        Time.timeScale = 1f; // ���� �ð��� ������ �� �� ��ȯ
        SceneManager.LoadScene("MainMenu"); // "MainMenu" �̸��� ������ ��ȯ
    }
}

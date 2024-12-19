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
        // ESC 키 입력 확인
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause(); // ESC 키 누르면 Pause 상태 전환
        }

        // 도움말 창이 켜진 상태에서만 추가 입력 처리
        if (isPaused)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                QuitGame(); // 게임 종료
            }
            else if (Input.GetKeyDown(KeyCode.M))
            {
                LoadMainMenu(); // 메인 메뉴로 전환
            }
            else if (Input.GetKeyDown(KeyCode.U))
            {
                ToggleMusic(); // 음악 ON/OFF 토글
            }
        }
    }

    void TogglePause()
    {
        if (isPaused)
        {
            // 게임 재개
            Time.timeScale = 1f; // 게임 속도 복원
            box.SetActive(false); // 도움말 박스 숨기기
            isPaused = false;
        }
        else
        {
            // 게임 멈춤
            Time.timeScale = 0f; // 게임 멈춤
            box.SetActive(true); // 도움말 박스 표시
            isPaused = true;
        }
    }

    void QuitGame()
    {
        Debug.Log("게임 종료");
        Application.Quit(); // 게임 종료
    }

    void ToggleMusic()
    {
        if (backgroundMusic != null)
        {
            isMusicOn = !isMusicOn;
            backgroundMusic.mute = !isMusicOn;
            Debug.Log(isMusicOn ? "음악 켜짐" : "음악 꺼짐");
        }
        else
        {
            Debug.LogWarning("Background Music 오브젝트가 연결되지 않았습니다.");
        }
    }

    void LoadMainMenu()
    {
        Debug.Log("메인 메뉴로 이동");
        Time.timeScale = 1f; // 게임 시간을 복원한 후 씬 전환
        SceneManager.LoadScene("MainMenu"); // "MainMenu" 이름의 씬으로 전환
    }
}

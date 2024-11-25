using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class farm_GameManager : MonoBehaviour
{
    public int maxLives = 3;          // 최대 목숨 수
    private int currentLives;         // 현재 목숨 수

    public GameObject[] traps;        // 함정 오브젝트 배열
    public GameObject[] items;        // 아이템 오브젝트 배열
    public GameObject[] platforms;    // 플랫폼 오브젝트 배열

    private Vector3 respawnPosition;  // 리스폰 위치
    private bool[] platformTouched;   // 각 플랫폼을 밟았는지 여부

    void Start()
    {
        currentLives = maxLives;      // 스테이지 시작 시 최대 목숨 수로 설정
        respawnPosition = transform.position; // 시작 위치를 초기 리스폰 위치로 설정
        platformTouched = new bool[platforms.Length]; // 각 플랫폼을 밟았는지 추적하기 위한 배열 초기화

        Debug.Log("Game Started. Current Lives: " + currentLives);

        // 모든 함정 오브젝트에 트리거 콜백 연결
        foreach (var trap in traps)
        {
            var trapCollider = trap.GetComponent<Collider>();
            if (trapCollider != null)
            {
                trapCollider.isTrigger = true;
            }
        }

        // 모든 아이템 오브젝트에 트리거 콜백 연결
        foreach (var item in items)
        {
            var itemCollider = item.GetComponent<Collider>();
            if (itemCollider != null)
            {
                itemCollider.isTrigger = true;
            }
        }

        // 모든 플랫폼 오브젝트에 트리거 콜백 연결
        foreach (var platform in platforms)
        {
            var platformCollider = platform.GetComponent<Collider>();
            if (platformCollider != null)
            {
                platformCollider.isTrigger = true;
            }
        }
    }

    void Update()
    {
        // 추락 시 리스폰 위치 체크
        TrackPlayerHeight();
    }

    // 목숨 증가 함수 (아이템을 먹었을 때 호출)
    public void AddLife()
    {
        if (currentLives < maxLives)
        {
            currentLives++;
            Debug.Log("Life added. Current Lives: " + currentLives);
        }
        else
        {
            Debug.Log("Lives are already at max. Current Lives: " + currentLives);
        }
    }

    // 목숨 감소 함수 (플랫폼 아래로 떨어지거나 함정을 밟았을 때 호출)
    public void LoseLife(bool respawn = false)
    {
        if (currentLives > 0)
        {
            currentLives--;
            Debug.Log("Life lost. Current Lives: " + currentLives);

            if (currentLives == 0)
            {
                GameOver(); // 목숨이 0이 되면 게임 종료
            }
            else if (respawn)
            {
                Respawn(); // 추락 시 리스폰
            }
        }
    }

    // 리스폰 처리
    void Respawn()
    {
        transform.position = respawnPosition;
        Debug.Log("Respawning at: " + respawnPosition);
    }

    // 게임 종료 함수
    void GameOver()
    {
        Debug.Log("Game Over! No lives remaining.");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // 트리거 충돌 처리
    void OnTriggerEnter(Collider other)
    {
        // 함정 처리
        foreach (var trap in traps)
        {
            if (other.gameObject == trap) // 충돌한 오브젝트가 함정인지 확인
            {
                LoseLife(); // 리스폰 없이 목숨만 차감
                return;
            }
        }

        // 아이템 처리
        foreach (var item in items)
        {
            if (other.gameObject == item) // 충돌한 오브젝트가 아이템인지 확인
            {
                AddLife();
                Destroy(other.gameObject); // 아이템을 먹은 후 파괴
                return;
            }
        }

        // 플랫폼을 밟았을 때 리스폰 위치 변경
        for (int i = 0; i < platforms.Length; i++)
        {
            if (other.gameObject == platforms[i] && !platformTouched[i]) // 첫 번째로 해당 플랫폼을 밟았으면
            {
                platformTouched[i] = true;  // 플랫폼을 밟았다고 표시
                SetRespawnPosition(i);      // 해당 플랫폼에 맞는 리스폰 위치 설정
                Debug.Log("Platform " + i + " touched. Respawn position set.");
                return;
            }
        }
    }

    // 플레이어 높이 추적
    void TrackPlayerHeight()
    {
        float playerHeight = transform.position.y;

        // 플랫폼 아래로 떨어졌는지 확인 (높이 0 이하)
        if (playerHeight < 0)
        {
            LoseLife(respawn: true); // 추락 시 리스폰 위치로 이동
        }
    }

    // 리스폰 위치 설정
    void SetRespawnPosition(int platformIndex)
    {
        // 각 플랫폼에 대한 리스폰 위치 설정 (플랫폼 순서에 맞춰 리스폰 위치 변경)
        if (platformIndex == 0)
        {
            respawnPosition = new Vector3(-10.12f, 13.392f, 18.46f); // 첫 번째 플랫폼
        }
        else if (platformIndex == 1)
        {
            respawnPosition = new Vector3(-13.52f, 14.15f, 9.66f); // 두 번째 플랫폼
        }
        else if (platformIndex == 2)
        {
            respawnPosition = new Vector3(0, 10f, 3f); // 세 번째 플랫폼
        }
    }
}

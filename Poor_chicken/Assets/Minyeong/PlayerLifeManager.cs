using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerLifeManager : MonoBehaviour
{
    public int maxLives = 3;          // 최대 목숨 수
    private int currentLives;         // 현재 목숨 수

    public GameObject[] traps;        // 함정 오브젝트 배열
    public GameObject[] items;        // 아이템 오브젝트 배열

    private Vector3 respawnPosition;  // 리스폰 위치
    private bool reachedHeight15 = false; // 높이 15 이상 도달 여부
    private bool reachedHeight18 = false; // 높이 18 이상 도달 여부

    void Start()
    {
        currentLives = maxLives;      // 스테이지 시작 시 최대 목숨 수로 설정
        respawnPosition = transform.position; // 시작 위치를 초기 리스폰 위치로 설정
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
    }

    void Update()
    {
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
        foreach (var trap in traps)
        {
            if (other.gameObject == trap) // 충돌한 오브젝트가 함정인지 확인
            {
                LoseLife(); // 리스폰 없이 목숨만 차감
                return;
            }
        }

        foreach (var item in items)
        {
            if (other.gameObject == item) // 충돌한 오브젝트가 아이템인지 확인
            {
                AddLife();
                Destroy(other.gameObject); // 아이템을 먹은 후 파괴
                return;
            }
        }
    }

    // 플레이어 높이 추적
    void TrackPlayerHeight()
    {
        float playerHeight = transform.position.y;

        if (playerHeight >= 18 && !reachedHeight18) // 도달 높이 18 이상 리스폰 위치
        {
            reachedHeight18 = true;
            respawnPosition = new Vector3(-13.52f, 14.15f, 9.66f);
            Debug.Log("Reached height 18. Respawn position set to: " + respawnPosition);
        }
        else if (playerHeight >= 13 && !reachedHeight15) // 도달 높이 13 이상 리스폰 위치
        {
            reachedHeight15 = true;
            respawnPosition = new Vector3(-10.12f, 13.392f, 18.46f);
            Debug.Log("Reached height 15. Respawn position set to: " + respawnPosition);
        }
        else if (playerHeight < 13 && !reachedHeight15) // 도달 높이 18 이하 리스폰 위치 (start 지점)
        {
            reachedHeight15 = true;
            respawnPosition = new Vector3(0, 10f, 3f);
            Debug.Log("Reached height 15. Respawn position set to: " + respawnPosition);
        }

        // 플랫폼 아래로 떨어졌는지 확인 (높이 0 이하)
        if (playerHeight < 0)
        {
            LoseLife(respawn: true); // 추락 시 리스폰 위치로 이동
        }
    }
}
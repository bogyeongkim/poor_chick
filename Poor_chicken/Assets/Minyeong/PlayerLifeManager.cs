using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI; // UI 네임스페이스 추가

public class PlayerLifeManager : MonoBehaviour
{
    public int maxLives = 3;          // 최대 목숨 수
    private int currentLives;         // 현재 목숨 수

    public GameObject[] traps;        // 함정 오브젝트 배열
    public GameObject[] items;        // 아이템 오브젝트 배열
    public GameObject[] platforms;    // 플랫폼 오브젝트 배열

    private Vector3 respawnPosition;  // 리스폰 위치
    private bool[] platformTouched;   // 각 플랫폼을 밟았는지 여부

    // 하트 UI를 위한 배열 (하트 이미지)
    public Image[] heartImages; // 3개의 하트 이미지를 담을 배열

    public AudioClip[] soundEffect;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        currentLives = maxLives;      // 스테이지 시작 시 최대 목숨 수로 설정
        respawnPosition = transform.position; // 시작 위치를 초기 리스폰 위치로 설정
        platformTouched = new bool[platforms.Length]; // 각 플랫폼을 밟았는지 추적하기 위한 배열 초기화

        UpdateHearts(); // 하트 UI 초기화

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

        // 모든 플랫폼 오브젝트에 BoxCollider 추가 및 isTrigger 켬
        foreach (var platform in platforms)
        {
            var platformCollider = platform.GetComponent<Collider>();
            if (platformCollider != null)
            {
                // MeshCollider의 isTrigger가 true로 설정되어 있지 않다면 이를 제거
                if (platformCollider is MeshCollider meshCollider)
                {
                    meshCollider.isTrigger = false; // MeshCollider는 트리거가 불가능
                }

                // BoxCollider가 없다면 추가하고 isTrigger 설정
                BoxCollider boxCollider = platform.GetComponent<BoxCollider>();
                if (boxCollider == null)
                {
                    boxCollider = platform.AddComponent<BoxCollider>();
                }
                boxCollider.isTrigger = true; // BoxCollider는 트리거 역할을 할 수 있도록 설정
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
            UpdateHearts(); // 하트 UI 업데이트
        }
        else
        {
            Debug.Log("Lives are already at max. Current Lives: " + currentLives);
        }
    }

    // 목숨 감소 함수 (플랫폼 아래로 떨어지거나 함정을 밟았을 때 호출)
    public void LoseLife(bool respawn = false)
    {
        audioSource.PlayOneShot(soundEffect[2]);
        if (currentLives > 0)
        {
            currentLives--;
            Debug.Log("Life lost. Current Lives: " + currentLives);
            UpdateHearts(); // 하트 UI 업데이트

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
        SceneManager.LoadScene("GameOver");
        audioSource.PlayOneShot(soundEffect[0]);
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
                audioSource.PlayOneShot(soundEffect[1]);
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
            respawnPosition = new Vector3(-20.069f, 15.63f, 9.829f); // 두 번째 플랫폼
        }
        else if (platformIndex == 2)
        {
            respawnPosition = new Vector3(-29.814f, 18.558f, 24.698f); // 세 번째 플랫폼
        }
    }

    // 하트 UI 갱신
    void UpdateHearts()
    {
        // 현재 목숨 수에 맞춰 하트의 활성화 상태를 변경
        for (int i = 0; i < heartImages.Length; i++)
        {
            if (i < currentLives)
            {
                heartImages[i].enabled = true; // 하트가 활성화
            }
            else
            {
                heartImages[i].enabled = false; // 하트가 비활성화
            }
        }
    }
}

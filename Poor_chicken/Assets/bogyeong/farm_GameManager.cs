using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI; 

public class farm_GameManager : MonoBehaviour
{
    public int maxLives = 3;          // 최대 목숨 수
    private int currentLives;         // 현재 목숨 수

    public GameObject[] traps;        // 함정 
    public GameObject[] items;        // 아이템 
    public GameObject[] platforms;    // 플랫폼 

    private Vector3 respawnPosition;  // 리스폰 위치
    private bool[] platformTouched;   // 각 플랫폼을 밟았는지 여부

    public Image[] heartImages; // 하트 이미지

    public AudioClip[] soundEffect;
    private AudioSource audioSource;

    void Start()
    {
        currentLives = maxLives;      // 스테이지 시작 시 최대 목숨 수로 설정
        respawnPosition = transform.position; // 시작 위치를 초기 리스폰 위치로 설정
        platformTouched = new bool[platforms.Length]; // 각 플랫폼을 밟았는지 추적

        audioSource = GetComponent<AudioSource>();

        Debug.Log("Game Started. Current Lives: " + currentLives);


        foreach (var item in items)
        {
            var itemCollider = item.GetComponent<Collider>();
            if (itemCollider != null)
            {
                itemCollider.isTrigger = true;
            }
        }

        foreach (var platform in platforms)
        {
            var platformCollider = platform.GetComponent<BoxCollider>();
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

    // 목숨 증가(아이템을 먹었을 때)
    public void AddLife()
    {
        UpdateHearts();
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

    // 목숨 감소(아래로 떨어지거나 함정 밟았을 때)
    public void LoseLife(bool respawn = false)
    {
        audioSource.PlayOneShot(soundEffect[2]);
        if (currentLives > 0)
        {
            currentLives--;
            Debug.Log("목숨 감소, 현재목숨 : " + currentLives);
            UpdateHearts();
            if (currentLives == 0)
            {
                GameOver(); // 목숨 0 되면 게임 종료
            }
            else if (respawn)
            {
                Respawn(); // 추락 시 리스폰
            }
        }
    }

    // 리스폰
    void Respawn()
    {
        transform.position = respawnPosition;
        Debug.Log("Respawning at: " + respawnPosition);
    }

    // 게임 종료
    void GameOver()
    {
        Debug.Log("Game Over! No lives remaining.");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        audioSource.PlayOneShot(soundEffect[0]);
    }

    void TrackPlayerHeight()
    {
        float playerHeight = transform.position.y;

        if (playerHeight < -30.0f)
        {
            LoseLife(respawn: true); // 추락 시 리스폰 위치로
        }
    }

    // 트리거 충돌 처리
    void OnTriggerEnter(Collider other)
    {
        // 함정
        foreach (var trap in traps)
        {
            if (other.gameObject == trap) // 함정인지 확인
            {
                LoseLife(); // 목숨만 차감
                
                return;
            }
        }

        // 아이템 
        foreach (var item in items)
        {
            if (other.gameObject == item) // 아이템인지 확인
            {
                AddLife();
                audioSource.PlayOneShot(soundEffect[1]);
                Destroy(other.gameObject); // 아이템 먹은 후 파괴
                return;
            }
        }

        // 리스폰 위치 설정
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

    // 리스폰 위치 설정
    void SetRespawnPosition(int platformIndex)
    {
        if (platformIndex >= 0 && platformIndex < platforms.Length)
        {
            Vector3 platformPosition = platforms[platformIndex].transform.position;

            respawnPosition = new Vector3(platformPosition.x, platformPosition.y + 3.0f, platformPosition.z);

            Debug.Log($"리스폰 설정 : {respawnPosition}");
        }
        else
        {
            Debug.LogWarning("리스폰 포인트 오류");
        }
    }

    // 하트 UI 갱신
    void UpdateHearts()
    {
        for (int i = 0; i < heartImages.Length; i++)
        {
            if (i < currentLives)
            {
                heartImages[i].enabled = true; 
            }
            else
            {
                heartImages[i].enabled = false; 
            }
        }
    }
}

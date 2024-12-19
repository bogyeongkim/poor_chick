using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI; 

public class farm_GameManager : MonoBehaviour
{
    public int maxLives = 3;          // �ִ� ��� ��
    private int currentLives;         // ���� ��� ��

    public GameObject[] traps;        // ���� 
    public GameObject[] items;        // ������ 
    public GameObject[] platforms;    // �÷��� 

    private Vector3 respawnPosition;  // ������ ��ġ
    private bool[] platformTouched;   // �� �÷����� ��Ҵ��� ����

    public Image[] heartImages; // ��Ʈ �̹���

    public AudioClip[] soundEffect;
    private AudioSource audioSource;

    void Start()
    {
        currentLives = maxLives;      // �������� ���� �� �ִ� ��� ���� ����
        respawnPosition = transform.position; // ���� ��ġ�� �ʱ� ������ ��ġ�� ����
        platformTouched = new bool[platforms.Length]; // �� �÷����� ��Ҵ��� ����

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
        // �߶� �� ������ ��ġ üũ
        TrackPlayerHeight();
    }

    // ��� ����(�������� �Ծ��� ��)
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

    // ��� ����(�Ʒ��� �������ų� ���� ����� ��)
    public void LoseLife(bool respawn = false)
    {
        audioSource.PlayOneShot(soundEffect[2]);
        if (currentLives > 0)
        {
            currentLives--;
            Debug.Log("��� ����, ������ : " + currentLives);
            UpdateHearts();
            if (currentLives == 0)
            {
                GameOver(); // ��� 0 �Ǹ� ���� ����
            }
            else if (respawn)
            {
                Respawn(); // �߶� �� ������
            }
        }
    }

    // ������
    void Respawn()
    {
        transform.position = respawnPosition;
        Debug.Log("Respawning at: " + respawnPosition);
    }

    // ���� ����
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
            LoseLife(respawn: true); // �߶� �� ������ ��ġ��
        }
    }

    // Ʈ���� �浹 ó��
    void OnTriggerEnter(Collider other)
    {
        // ����
        foreach (var trap in traps)
        {
            if (other.gameObject == trap) // �������� Ȯ��
            {
                LoseLife(); // ����� ����
                
                return;
            }
        }

        // ������ 
        foreach (var item in items)
        {
            if (other.gameObject == item) // ���������� Ȯ��
            {
                AddLife();
                audioSource.PlayOneShot(soundEffect[1]);
                Destroy(other.gameObject); // ������ ���� �� �ı�
                return;
            }
        }

        // ������ ��ġ ����
        for (int i = 0; i < platforms.Length; i++)
        {
            if (other.gameObject == platforms[i] && !platformTouched[i]) // ù ��°�� �ش� �÷����� �������
            {
                platformTouched[i] = true;  // �÷����� ��Ҵٰ� ǥ��
                SetRespawnPosition(i);      // �ش� �÷����� �´� ������ ��ġ ����
                Debug.Log("Platform " + i + " touched. Respawn position set.");
                return;
            }
        }
    }

    // ������ ��ġ ����
    void SetRespawnPosition(int platformIndex)
    {
        if (platformIndex >= 0 && platformIndex < platforms.Length)
        {
            Vector3 platformPosition = platforms[platformIndex].transform.position;

            respawnPosition = new Vector3(platformPosition.x, platformPosition.y + 3.0f, platformPosition.z);

            Debug.Log($"������ ���� : {respawnPosition}");
        }
        else
        {
            Debug.LogWarning("������ ����Ʈ ����");
        }
    }

    // ��Ʈ UI ����
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title_music : MonoBehaviour
{
    public static Title_music instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            // �� �ٲ� ������Ʈ ����, �ʹ� �ѹ��� ������Ʈ ����&�Ҵ�, ���� ��� ������������ ���� ����
            SceneManager.sceneLoaded += OnSceneLoaded; 
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "IntroVideo")
        {
            Destroy(gameObject); 
        }
    }
}

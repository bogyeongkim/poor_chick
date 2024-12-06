using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class videoskip : MonoBehaviour
{

    void Awake()
    {
        DontDestroyOnLoad(gameObject); // ������Ʈ�� �� ��ȯ �� ����
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded; // �� �ε� �̺�Ʈ ����
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded; // �� �ε� �̺�Ʈ ����
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "iceland")
        {
            Destroy(gameObject); // Ư�� �� �ε� �� ������Ʈ ����
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void skipintro()
    {
        SceneManager.LoadScene("iceland");
    }
}

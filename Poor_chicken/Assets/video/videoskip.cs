using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class videoskip : MonoBehaviour
{

    void Awake()
    {
        DontDestroyOnLoad(gameObject); // 오브젝트를 씬 전환 시 유지
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded; // 씬 로드 이벤트 구독
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded; // 씬 로드 이벤트 해제
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "iceland")
        {
            Destroy(gameObject); // 특정 씬 로드 시 오브젝트 삭제
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

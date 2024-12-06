using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Videonext : MonoBehaviour
{
    public VideoPlayer videoPlayer; // VideoPlayer 컴포넌트를 참조

    public string scenename;

    void Start()
    {
        // VideoPlayer의 끝 이벤트에 이벤트 리스너 추가
        videoPlayer.loopPointReached += OnVideoEnd;
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        // 다음 씬으로 전환
        SceneManager.LoadScene(scenename);
    }
}

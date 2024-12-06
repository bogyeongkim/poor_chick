using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Videonext : MonoBehaviour
{
    public VideoPlayer videoPlayer; // VideoPlayer ������Ʈ�� ����

    public string scenename;

    void Start()
    {
        // VideoPlayer�� �� �̺�Ʈ�� �̺�Ʈ ������ �߰�
        videoPlayer.loopPointReached += OnVideoEnd;
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        // ���� ������ ��ȯ
        SceneManager.LoadScene(scenename);
    }
}

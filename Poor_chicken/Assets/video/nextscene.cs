using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;

public class nextscene : MonoBehaviour
{
    public PlayableDirector playableDirector; // Ÿ�Ӷ����� �����ϴ� PlayableDirector

    void Start()
    {
        // PlayableDirector�� ����� �� ȣ��� �̺�Ʈ�� ���
        playableDirector.stopped += OnTimelineFinished;
    }

    void OnTimelineFinished(PlayableDirector director)
    {
        // Ÿ�Ӷ����� ������ ���� ������ ��ȯ
        SceneManager.LoadScene("iceland");
    }

    void OnDestroy()
    {
        // ��ü�� �ı��� �� �̺�Ʈ ���� ����
        playableDirector.stopped -= OnTimelineFinished;
    }
}

using UnityEngine;
using UnityEngine.Playables;

public class ending : MonoBehaviour
{
    public PlayableDirector playableDirector;  // Ÿ�Ӷ����� �����ϴ� PlayableDirector
    public GameObject canvasToActivate;        // Ȱ��ȭ�� ĵ���� ������Ʈ

    void Start()
    {
        // Ÿ�Ӷ����� ����� �� ȣ��� �̺�Ʈ�� ���
        playableDirector.stopped += OnTimelineFinished;
    }

    void OnTimelineFinished(PlayableDirector director)
    {
        // Ÿ�Ӷ��� ���� �� ĵ������ Ȱ��ȭ
        if (canvasToActivate != null)
        {
            canvasToActivate.SetActive(true);  // ĵ������ Ȱ��ȭ
        }
    }

    void OnDestroy()
    {
        // ��ü�� �ı��� �� �̺�Ʈ ���� ����
        playableDirector.stopped -= OnTimelineFinished;
    }
}

using UnityEngine;
using UnityEngine.Playables;

public class ending : MonoBehaviour
{
    public PlayableDirector playableDirector;  // 타임라인을 제어하는 PlayableDirector
    public GameObject canvasToActivate;        // 활성화할 캔버스 오브젝트

    void Start()
    {
        // 타임라인이 종료될 때 호출될 이벤트를 등록
        playableDirector.stopped += OnTimelineFinished;
    }

    void OnTimelineFinished(PlayableDirector director)
    {
        // 타임라인 종료 시 캔버스를 활성화
        if (canvasToActivate != null)
        {
            canvasToActivate.SetActive(true);  // 캔버스를 활성화
        }
    }

    void OnDestroy()
    {
        // 객체가 파괴될 때 이벤트 구독 해제
        playableDirector.stopped -= OnTimelineFinished;
    }
}

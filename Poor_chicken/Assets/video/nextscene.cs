using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;

public class nextscene : MonoBehaviour
{
    public PlayableDirector playableDirector; // 타임라인을 제어하는 PlayableDirector

    void Start()
    {
        // PlayableDirector가 종료될 때 호출될 이벤트를 등록
        playableDirector.stopped += OnTimelineFinished;
    }

    void OnTimelineFinished(PlayableDirector director)
    {
        // 타임라인이 끝나면 다음 씬으로 전환
        SceneManager.LoadScene("iceland");
    }

    void OnDestroy()
    {
        // 객체가 파괴될 때 이벤트 구독 해제
        playableDirector.stopped -= OnTimelineFinished;
    }
}

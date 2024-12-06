using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationLoop : MonoBehaviour
{
    public Animator animator;  // Animator 컴포넌트를 연결할 변수
    private string[] animations = { "idle_0", "idle_1", "idle_4" };  // 반복할 애니메이션 이름들
    private int currentAnimationIndex = 0;  // 현재 애니메이션 인덱스

    void Start()
    {
        // Animator 컴포넌트를 자동으로 찾음
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }

        // 첫 애니메이션을 바로 시작
        PlayNextAnimation();
    }

    void Update()
    {
        // 애니메이션이 끝날 때마다 다음 애니메이션으로 넘어가도록 체크
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName(animations[currentAnimationIndex]))
        {
            PlayNextAnimation();
        }
    }

    // 다음 애니메이션을 재생
    void PlayNextAnimation()
    {
        // 현재 애니메이션 인덱스를 업데이트하고, 해당 애니메이션을 플레이
        animator.Play(animations[currentAnimationIndex]);

        // 인덱스를 순차적으로 변경하고, 배열 끝에 도달하면 처음으로 돌아옴
        currentAnimationIndex = (currentAnimationIndex + 1) % animations.Length;
    }
}

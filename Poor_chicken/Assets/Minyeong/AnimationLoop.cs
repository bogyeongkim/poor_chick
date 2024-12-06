using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationLoop : MonoBehaviour
{
    public Animator animator;  // Animator ������Ʈ�� ������ ����
    private string[] animations = { "idle_0", "idle_1", "idle_4" };  // �ݺ��� �ִϸ��̼� �̸���
    private int currentAnimationIndex = 0;  // ���� �ִϸ��̼� �ε���

    void Start()
    {
        // Animator ������Ʈ�� �ڵ����� ã��
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }

        // ù �ִϸ��̼��� �ٷ� ����
        PlayNextAnimation();
    }

    void Update()
    {
        // �ִϸ��̼��� ���� ������ ���� �ִϸ��̼����� �Ѿ���� üũ
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName(animations[currentAnimationIndex]))
        {
            PlayNextAnimation();
        }
    }

    // ���� �ִϸ��̼��� ���
    void PlayNextAnimation()
    {
        // ���� �ִϸ��̼� �ε����� ������Ʈ�ϰ�, �ش� �ִϸ��̼��� �÷���
        animator.Play(animations[currentAnimationIndex]);

        // �ε����� ���������� �����ϰ�, �迭 ���� �����ϸ� ó������ ���ƿ�
        currentAnimationIndex = (currentAnimationIndex + 1) % animations.Length;
    }
}

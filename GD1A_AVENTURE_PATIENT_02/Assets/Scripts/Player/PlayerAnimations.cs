using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private readonly int horizontal = Animator.StringToHash("Horizontal");
    private readonly int vertical = Animator.StringToHash("Vertical");
    private readonly int speed = Animator.StringToHash("Speed");
    private readonly int dead = Animator.StringToHash("Dead");

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void ShowDeadAnimation()
    {
        animator.SetTrigger(dead);
    }

    public void SetMovingAnimation(Vector2 dir)
    {
        animator.SetFloat("Horizontal", dir.x);
        animator.SetFloat("Vertical", dir.y);
        animator.SetFloat("Speed", dir.sqrMagnitude);
    }

    public void SetIdleAnimation(Vector2 dir)
    {
        animator.SetFloat("LastHorizontal", dir.x);
        animator.SetFloat("LastVertical", dir.y);
    }
}
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class AnimationEvent : MonoBehaviour
{
    private Animator animator = null;
    private int currentLayer;

    public Animator GetAnimator { get { return animator; } }

    public AnimationEvent(Animator animator)
    {
        this.animator = animator;
        currentLayer = 0;
    }

    public void SetLayer(int index)
    {
        currentLayer = index;
    }

    public bool IsOverPlaytime(string tag)
    {
        if (animator.GetCurrentAnimatorStateInfo(currentLayer).IsTag(tag) && 
            animator.GetCurrentAnimatorStateInfo(currentLayer).normalizedTime >= 1.0f) return true;
        else return false;
    }

    public bool IsPlaytimeInRange(float min, float max)
    {
        if (min <= animator.GetCurrentAnimatorStateInfo(currentLayer).normalizedTime &&
            animator.GetCurrentAnimatorStateInfo(currentLayer).normalizedTime <= max) return true;
        else return false;
    }
}

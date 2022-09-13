using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class AnimationEvent
{
    public bool IsOverPlaytime(Animator anim, string tag, int layer = 0)
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsTag(tag) &&
            anim.GetCurrentAnimatorStateInfo(layer).normalizedTime >= 1.0f) return true;
        else return false;
    }

    public bool IsPlaytimeOverTime(Animator anim, string tag, float time, int layer = 0)
    {
        if (anim.GetCurrentAnimatorStateInfo(layer).IsTag(tag) &&
            anim.GetCurrentAnimatorStateInfo(layer).normalizedTime >= time) return true;
        else return false;
    }

    public bool IsPlaytimeInRange(Animator anim, string tag, float min, float max, int layer = 0)
    {
        if (anim.GetCurrentAnimatorStateInfo(layer).IsTag(tag) &&
            min <= anim.GetCurrentAnimatorStateInfo(layer).normalizedTime &&
            anim.GetCurrentAnimatorStateInfo(layer).normalizedTime <= max) return true;
        else return false;
    }
}

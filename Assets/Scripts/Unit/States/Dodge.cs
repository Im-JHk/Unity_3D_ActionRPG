using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dodge : ActionState
{
    public Dodge(Unit unit)
    {
        this.unit = unit;
    }

    override public void StateEnter()
    {
        unit.CanChangeState = false;
        unit.IsDodge = true;
        //unit.GetAnimator.SetBool("IsDodge", true);
        unit.GetAnimator.SetTrigger("OnDodge");
        unit.GetActionState = Unit.ActionState.Dodge;
        Debug.Log("Dodge Enter");
    }

    override public void StateStay()
    {
        //Debug.Log("Dodge Stay");
        unit.Dodge();
    }

    override public void StateExit()
    {
        Debug.Log("Dodge Exit");
        unit.CanChangeState = true;
        unit.IsDodge = false;
        //unit.GetAnimator.SetBool("IsDodge", false);
        unit.GetActionState = Unit.ActionState.None;
    }
}

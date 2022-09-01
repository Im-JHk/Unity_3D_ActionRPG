using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dodge : LowerState
{
    public Dodge(Unit unit)
    {
        this.unit = unit;
    }

    override public void StateEnter()
    {
        unit.CanChangeState = false;
        unit.GetAnimator.SetBool("IsDodge", true);
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
        unit.GetAnimator.SetBool("IsDodge", false);
    }
}

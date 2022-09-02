using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defend : ActionState
{
    public Defend(Unit unit)
    {
        this.unit = unit;

    }
    override public void StateEnter()
    {
        Debug.Log("Defend Enter");
        unit.CanChangeState = false;
        unit.GetActionState = Unit.ActionState.Defend;
    }

    override public void StateStay()
    {
        Debug.Log("Defend Stay");
    }

    override public void StateExit()
    {
        Debug.Log("Defend Exit");
        unit.CanChangeState = true;
        unit.GetActionState = Unit.ActionState.None;
    }
}

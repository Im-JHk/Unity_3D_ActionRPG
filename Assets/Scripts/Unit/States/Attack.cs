using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : ActionState
{
    public Attack(Unit unit)
    {
        StateType = Unit.BaseState.Attack;
        this.unit = unit;
    }

    override public void StateEnter()
    {
        Debug.Log("Attack Enter");
        unit.CanChangeState = false;
        unit.GetActionState = Unit.ActionState.Attack;
    }

    override public void StateStay()
    {
        Debug.Log("Attack Stay");
        unit.Attack();
    }

    override public void StateExit()
    {
        Debug.Log("Attack Exit");
        unit.CanChangeState = true;
        unit.GetActionState = Unit.ActionState.None;
    }
}

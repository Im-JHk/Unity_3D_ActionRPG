using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : MoveState
{
    public Idle(Unit unit)
    {
        this.unit = unit;
        StateType = Unit.BaseState.Idle;
    }

    override public void StateEnter()
    {
        //Debug.Log("Idle Enter");
        unit.LookVector = Vector3.zero;
        unit.GetMoveState = Unit.MoveState.Idle;
    }

    override public void StateStay()
    {
        //Debug.Log("Idle Stay");
    }

    override public void StateExit()
    {
        //Debug.Log("Idle Exit");
        unit.GetMoveState = Unit.MoveState.None;
    }
}

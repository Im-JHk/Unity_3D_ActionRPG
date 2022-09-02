using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : MoveState
{
    public Walk(Unit unit)
    {
        this.unit = unit;
    }

    override public void StateEnter()
    {
        //Debug.Log("Walk Enter");
        unit.IsMove = true;
        unit.GetMoveState = Unit.MoveState.Walk;
    }

    override public void StateStay()
    {
        //Debug.Log("Walk Stay");
        unit.Move();
    }

    override public void StateExit()
    {
        //Debug.Log("Walk Exit");
        if(unit.MoveVector == Vector3.zero) unit.IsMove = false;
        unit.LookVector = unit.MoveVector;
        unit.Move();
        unit.GetMoveState = Unit.MoveState.None;
    }
}

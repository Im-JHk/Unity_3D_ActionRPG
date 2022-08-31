using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run : LowerState
{
    public Run(Unit unit)
    {
        this.unit = unit;
    }

    override public void StateEnter()
    {
        //Debug.Log("Run Enter");
        unit.MoveSpeed *= 2f;
    }

    override public void StateStay()
    {
        //Debug.Log("Run Stay");
        unit.Move();
    }

    override public void StateExit()
    {
        Debug.Log("Run Exit");
        Debug.Log(unit.MoveVector);
        Debug.Log(unit.IsMove + " b ");
        if (unit.MoveVector == Vector3.zero) unit.IsMove = false;
        Debug.Log(unit.IsMove + " a ");
        unit.IsRun = false;
        unit.MoveSpeed *= 0.5f;
        unit.Move();
    }
}

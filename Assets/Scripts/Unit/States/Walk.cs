using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : LowerState
{
    public Walk(Unit unit)
    {
        this.unit = unit;
    }

    override public void StateEnter()
    {
        //Debug.Log("Walk Enter");
        unit.IsMove = true;
    }

    override public void StateStay()
    {
        //Debug.Log("Walk Stay");
        unit.Move();
    }

    override public void StateExit()
    {
        Debug.Log("Walk Exit");
        Debug.Log(unit.MoveVector);
        if(unit.MoveVector == Vector3.zero) unit.IsMove = false;
        unit.Move();
    }
}

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
        Debug.Log("Walk Enter");
    }

    override public void StateStay()
    {
        Debug.Log("Walk Stay");
        unit.Move();
        unit.Rotate();
    }

    override public void StateExit()
    {
        Debug.Log("Walk Exit");
    }
}

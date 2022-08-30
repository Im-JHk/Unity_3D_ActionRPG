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
        Debug.Log("Run Enter");
    }

    override public void StateStay()
    {
        Debug.Log("Run Stay");
        unit.Move();
        unit.Rotate();
    }

    override public void StateExit()
    {
        Debug.Log("Run Exit");
    }
}

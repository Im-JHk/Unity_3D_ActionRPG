using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : LowerState
{
    public Idle(Unit unit)
    {
        this.unit = unit;
    }

    override public void StateEnter()
    {
        //Debug.Log("Idle Enter");
    }

    override public void StateStay()
    {
        //Debug.Log("Idle Stay");
    }

    override public void StateExit()
    {
        //Debug.Log("Idle Exit");
    }
}

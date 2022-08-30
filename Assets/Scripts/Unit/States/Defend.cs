using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defend : UpperState
{
    public Defend(Unit unit)
    {
        this.unit = unit;

    }
    override public void StateEnter()
    {
        Debug.Log("Defend Enter");
    }

    override public void StateStay()
    {
        Debug.Log("Defend Stay");
    }

    override public void StateExit()
    {
        Debug.Log("Defend Exit");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : UpperState
{
    public Attack(Unit unit)
    {
        this.unit = unit;
    }

    override public void StateEnter()
    {
        Debug.Log("Attack Enter");
    }

    override public void StateStay()
    {
        Debug.Log("Attack Stay");
    }

    override public void StateExit()
    {
        Debug.Log("Attack Exit");
    }
}

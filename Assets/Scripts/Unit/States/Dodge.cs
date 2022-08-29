using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dodge : LowerState
{
    private Player.PlayerState state = Player.PlayerState.Idle;
    public Player.PlayerState State { get { return state; } private set { state = value; } }

    override public void StateEnter()
    {
        Debug.Log("Dodge Enter");
    }

    override public void StateStay()
    {
        Debug.Log("Dodge Stay");
    }

    override public void StateExit()
    {
        Debug.Log("Dodge Exit");
    }
}

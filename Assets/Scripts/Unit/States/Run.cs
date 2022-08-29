using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run : LowerState
{
    private Player.PlayerState state = Player.PlayerState.Idle;
    public Player.PlayerState State { get { return state; } private set { state = value; } }

    override public void StateEnter()
    {
        Debug.Log("Run Enter");
    }

    override public void StateStay()
    {
        Debug.Log("Run Stay");
    }

    override public void StateExit()
    {
        Debug.Log("Run Exit");
    }
}

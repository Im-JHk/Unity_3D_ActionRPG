using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : LowerState
{
    private Player.PlayerState state = Player.PlayerState.Idle;
    private Vector2 moveAxis;

    public Player.PlayerState State { get { return state; } private set { state = value; } }
    public Vector2 MoveAxis { get { return moveAxis; } set { moveAxis = value; } }

    override public void StateEnter()
    {
        Debug.Log("Walk Enter");
    }

    override public void StateStay()
    {
        Debug.Log("Walk Stay");
    }

    override public void StateExit()
    {
        Debug.Log("Walk Exit");
    }
}

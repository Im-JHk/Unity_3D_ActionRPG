using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : LowerState
{
    private Player.PlayerState state = Player.PlayerState.Idle;
    public Player.PlayerState State { get { return state; } private set { state = value; } }

    override public void StateEnter()
    {
        Debug.Log("Idle Enter");
    }
    override public void StateStay()
    {
        Debug.Log("Idle Stay");
    }
    override public void StateExit()
    {
        Debug.Log("Idle Exit");
    }
}

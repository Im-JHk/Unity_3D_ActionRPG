using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defend : UpperState
{
    private Player.PlayerState state = Player.PlayerState.Defend;
    public Player.PlayerState State { get { return state; } private set { state = value; } }

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

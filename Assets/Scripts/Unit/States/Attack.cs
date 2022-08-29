using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : UpperState
{
    private Player.PlayerState state = Player.PlayerState.Attack;
    public Player.PlayerState State { get { return state; } private set { state = value; } }

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

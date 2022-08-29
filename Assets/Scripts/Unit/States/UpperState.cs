using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpperState : IState
{
    private float elapsedTime;
    private float releaseTime = 1.0f;

    virtual public void StateEnter()
    {
        elapsedTime = 0;
        Debug.Log("UpperState Enter");
    }

    virtual public void StateStay()
    {
        elapsedTime += Time.deltaTime;
        Debug.Log("UpperState Stay");
    }

    virtual public void StateExit()
    {
        Debug.Log("UpperState Exit");
    }

    virtual public bool CanInput(Player.PlayerState newState)
    {
        if (elapsedTime > releaseTime) return true;
        else return false;
    }
}

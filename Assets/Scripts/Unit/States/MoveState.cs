using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : IState
{
    protected Unit unit = null;
    private float elapsedTime;
    private float releaseTime = 1.0f;

    virtual public void StateEnter()
    {
        elapsedTime = 0;
        Debug.Log("MoveState Enter");
    }

    virtual public void StateStay()
    {
        elapsedTime += Time.deltaTime;
        Debug.Log("MoveState Stay");
    }

    virtual public void StateExit()
    {
        Debug.Log("MoveState Exit");
    }
}

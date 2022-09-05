using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : IState
{
    protected Unit.BaseState stateType;
    protected Unit unit = null;

    private float elapsedTime;
    private float releaseTime = 1.0f;

    public Unit.BaseState StateType { get { return stateType; } protected set { stateType = value; } }

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

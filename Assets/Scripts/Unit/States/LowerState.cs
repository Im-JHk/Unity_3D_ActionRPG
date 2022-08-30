using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowerState : IState
{
    protected Unit unit = null;
    private float elapsedTime;
    private float releaseTime = 1.0f;

    virtual public void StateEnter()
    {
        elapsedTime = 0;
        Debug.Log("LowerState Enter");
    }

    virtual public void StateStay()
    {
        elapsedTime += Time.deltaTime;
        Debug.Log("LowerState Stay");
    }

    virtual public void StateExit()
    {
        Debug.Log("LowerState Exit");
    }
}

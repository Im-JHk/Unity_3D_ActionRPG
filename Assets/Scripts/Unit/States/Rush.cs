using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NS_State
{
    public class Rush : ActionState
    {
        public Rush(Unit unit)
        {
            StateType = NS_Unit.BaseState.Run;
            this.unit = unit;
        }

        override public void StateEnter()
        {
            unit.IsRun = true;
        }

        override public void StateStay()
        {
            //Debug.Log("Run Stay");
            unit.SetMoveParameter();
            unit.Move();
        }

        override public void StateExit()
        {
            //Debug.Log("Run Exit");
            if (unit.MoveVector == Vector3.zero)
            {
                unit.IsMove = false;
            }
            unit.IsRun = false;
            unit.MoveSpeed *= 0.5f;
            unit.MoveState = NS_Unit.MoveState.None;
            unit.SetMoveParameter();
        }
    }
}

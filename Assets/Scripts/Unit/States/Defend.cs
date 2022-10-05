using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NS_State
{
    public class Defend : ActionState
    {
        public Defend(Unit unit)
        {
            StateType = NS_Unit.BaseState.Defend;
            this.unit = unit;
        }
        override public void StateEnter()
        {
            unit.CanChangeState = false;
            unit.ActionState = NS_Unit.ActionState.Defend;
            unit.Animator.SetBool(unit.HashIsDefend, true);
            unit.Defend();
        }

        override public void StateStay()
        {
            unit.SetMoveParameter();
            unit.Move();
        }

        override public void StateExit()
        {
            unit.CanChangeState = true;
            unit.ActionState = NS_Unit.ActionState.None;
            unit.Animator.SetBool(unit.HashIsDefend, false);
        }
    }
}

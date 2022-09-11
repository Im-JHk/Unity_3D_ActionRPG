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
            Debug.Log("Defend Enter");
            unit.CanChangeState = false;
            unit.ActionState = NS_Unit.ActionState.Defend;
        }

        override public void StateStay()
        {
            Debug.Log("Defend Stay");
        }

        override public void StateExit()
        {
            Debug.Log("Defend Exit");
            unit.CanChangeState = true;
            unit.ActionState = NS_Unit.ActionState.None;
        }
    }
}

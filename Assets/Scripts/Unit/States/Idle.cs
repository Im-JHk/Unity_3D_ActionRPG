using UnityEngine;

namespace NS_State
{
    public class Idle : MoveState
    {
        public Idle(Unit unit)
        {
            this.unit = unit;
            StateType = NS_Unit.BaseState.Idle;
        }

        override public void StateEnter()
        {
            unit.MoveState = NS_Unit.MoveState.Idle;
        }

        override public void StateStay()
        {
        }

        override public void StateExit()
        {
            unit.MoveState = NS_Unit.MoveState.None;
        }
    }
}
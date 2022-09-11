using UnityEngine;

namespace NS_State
{
    public class Walk : MoveState
    {
        public Walk(Unit unit)
        {
            StateType = NS_Unit.BaseState.Walk;
            this.unit = unit;
        }

        override public void StateEnter()
        {
            //Debug.Log("Walk Enter");
            unit.IsMove = true;
            unit.MoveState = NS_Unit.MoveState.Walk;
        }

        override public void StateStay()
        {
            //Debug.Log("Walk Stay");
            unit.Move();
        }

        override public void StateExit()
        {
            //Debug.Log("Walk Exit");
            if (unit.MoveVector == Vector3.zero) unit.IsMove = false;
            if (unit.UnitType == NS_Unit.UnitType.Player) unit.SetMoveParameter();
            unit.MoveState = NS_Unit.MoveState.None;
        }
    }
}
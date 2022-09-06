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
            unit.GetMoveState = NS_Unit.MoveState.Walk;
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
            unit.LookVector = unit.MoveVector;
            if (unit.GetUnitType == NS_Unit.UnitType.Player) unit.Move();
            unit.GetMoveState = NS_Unit.MoveState.None;
        }
    }
}
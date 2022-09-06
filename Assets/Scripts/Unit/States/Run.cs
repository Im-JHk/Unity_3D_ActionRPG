using UnityEngine;

namespace NS_State
{
    public class Run : MoveState
    {
        public Run(Unit unit)
        {
            StateType = NS_Unit.BaseState.Run;
            this.unit = unit;
        }

        override public void StateEnter()
        {
            //Debug.Log("Run Enter");
            unit.MoveSpeed *= 2f;
            unit.GetMoveState = NS_Unit.MoveState.Run;
        }

        override public void StateStay()
        {
            //Debug.Log("Run Stay");
            unit.Move();
        }

        override public void StateExit()
        {
            //Debug.Log("Run Exit");
            if (unit.MoveVector == Vector3.zero) unit.IsMove = false;
            unit.IsRun = false;
            unit.LookVector = unit.MoveVector;
            unit.MoveSpeed *= 0.5f;
            unit.Move();
            unit.GetMoveState = NS_Unit.MoveState.None;
        }
    }
}
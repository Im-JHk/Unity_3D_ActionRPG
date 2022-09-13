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
            unit.IsRun = true;
            unit.MoveSpeed *= 2f;
            unit.MoveState = NS_Unit.MoveState.Run;
            unit.SetMoveParameter();
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
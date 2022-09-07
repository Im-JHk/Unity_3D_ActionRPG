using UnityEngine;

namespace NS_State
{
    public class Attack : ActionState
    {
        public Attack(Unit unit)
        {
            StateType = NS_Unit.BaseState.Attack;
            this.unit = unit;
        }

        override public void StateEnter()
        {
            Debug.Log("Attack Enter");
            unit.CanChangeState = false;
            unit.GetActionState = NS_Unit.ActionState.Attack;
            unit.Attack();
        }

        override public void StateStay()
        {
            Debug.Log("Attack Stay");
        }

        override public void StateExit()
        {
            Debug.Log("Attack Exit");
            unit.CanChangeState = true;
            unit.GetActionState = NS_Unit.ActionState.None;
        }
    }
}
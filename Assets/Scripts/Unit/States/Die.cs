using UnityEngine;

namespace NS_State
{
    public class Die : ActionState
    {
        public Die(Unit unit)
        {
            StateType = NS_Unit.BaseState.Die;
            this.unit = unit;
        }

        override public void StateEnter()
        {
            unit.CanChangeState = false;
            unit.ActionState = NS_Unit.ActionState.Die;
            unit.Animator.SetTrigger(unit.HashOnDie);
            unit.Die();
        }

        override public void StateStay()
        {
        }

        override public void StateExit()
        {
            unit.CanChangeState = true;
            unit.ActionState = NS_Unit.ActionState.None;
        }
    }
}
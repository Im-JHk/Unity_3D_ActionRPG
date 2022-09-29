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
            Debug.Log("Die Enter");
            unit.CanChangeState = false;
            unit.ActionState = NS_Unit.ActionState.Die;
            unit.Animator.SetBool(unit.HashIsDie, true);
        }

        override public void StateStay()
        {
            //Debug.Log("Die Stay");
        }

        override public void StateExit()
        {
            Debug.Log("Die Exit");
            unit.CanChangeState = true;
            unit.ActionState = NS_Unit.ActionState.None;
            unit.Animator.SetBool(unit.HashIsDie, false);
        }
    }
}
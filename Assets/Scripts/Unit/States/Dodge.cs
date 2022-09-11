using UnityEngine;

namespace NS_State
{
    public class Dodge : ActionState
    {
        public Dodge(Unit unit)
        {
            StateType = NS_Unit.BaseState.Dodge;
            this.unit = unit;
        }

        override public void StateEnter()
        {
            unit.CanChangeState = false;
            unit.IsDodge = true;
            unit.GetAnimationEvent.GetAnimator.SetTrigger("OnDodge");
            unit.ActionState = NS_Unit.ActionState.Dodge;
            Debug.Log("Dodge Enter");
        }

        override public void StateStay()
        {
            //Debug.Log("Dodge Stay");
            unit.Dodge();
        }

        override public void StateExit()
        {
            Debug.Log("Dodge Exit");
            unit.CanChangeState = true;
            unit.IsDodge = false;
            unit.ActionState = NS_Unit.ActionState.None;
        }
    }
}
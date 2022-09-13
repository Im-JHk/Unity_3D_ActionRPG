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
            isExitReady = false;
            unit.CanChangeState = false;
            unit.IsDodge = true;
            unit.ActionState = NS_Unit.ActionState.Dodge;
            unit.Animator.SetTrigger(unit.HashOnDodge);
            unit.Dodge();
            Debug.Log("Dodge Enter");
        }

        override public void StateStay()
        {
            //Debug.Log("Dodge Stay");
            if (unit.AnimationEvent.IsPlaytimeOverTime(unit.Animator, "Dodge", 0.5f))
                unit.Rigidbody.velocity = Vector3.Lerp(unit.Rigidbody.velocity, Vector3.zero, Time.deltaTime);
            if (unit.AnimationEvent.IsOverPlaytime(unit.Animator, "Dodge")) isExitReady = true;
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
using UnityEngine;

namespace NS_State
{
    public class MoveState : IState
    {
        protected Unit unit = null;
        protected NS_Unit.BaseState stateType;
        protected bool isExitReady = false;

        public NS_Unit.BaseState StateType { get { return stateType; } protected set { stateType = value; } }

        virtual public void StateEnter()
        {
            Debug.Log("MoveState Enter");
        }

        virtual public void StateStay()
        {
            Debug.Log("MoveState Stay");
        }

        virtual public void StateExit()
        {
            Debug.Log("MoveState Exit");
        }

        virtual public bool IsExitReady()
        {
            return isExitReady;
        }
    }
}
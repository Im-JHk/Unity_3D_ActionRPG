using UnityEngine;

namespace NS_State
{
    public class MoveState : IState
    {
        protected NS_Unit.BaseState stateType;
        protected Unit unit = null;

        private float elapsedTime;
        private float releaseTime = 1.0f;

        public NS_Unit.BaseState StateType { get { return stateType; } protected set { stateType = value; } }

        virtual public void StateEnter()
        {
            elapsedTime = 0;
            Debug.Log("MoveState Enter");
        }

        virtual public void StateStay()
        {
            elapsedTime += Time.deltaTime;
            Debug.Log("MoveState Stay");
        }

        virtual public void StateExit()
        {
            Debug.Log("MoveState Exit");
        }
    }
}
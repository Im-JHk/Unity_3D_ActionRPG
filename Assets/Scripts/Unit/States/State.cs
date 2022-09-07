using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NS_State
{
    public class State
    {
        private IState currentState = null;

        public IState CurrentState { get { return currentState; } private set { currentState = value; } }

        public State(IState state)
        {
            this.currentState = state;
        }

        public void StateUpdate()
        {
            if(this.currentState != null) this.currentState.StateStay();
        }

        public void SetState(IState state)
        {
            if (this.currentState == state)
            {
                return;
            }
            this.currentState.StateExit();
            this.currentState = state;
            this.currentState.StateEnter();
        }

        //public bool CanInputCheck(Player.PlayerState newState)
        //{
        //    if (this.currentState.CanInput(newState)) return true;
        //    else return false;
        //}
    }
}
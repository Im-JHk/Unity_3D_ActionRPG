using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NS_State
{
    public class State
    {
        public IState CurrentState { get; private set; }

        public State(IState state)
        {
            CurrentState = state;
        }

        public void StateUpdate()
        {
            if(CurrentState != null) CurrentState.StateStay();
        }

        public void SetState(IState state)
        {
            if (CurrentState == state) return;
            CurrentState.StateExit();
            CurrentState = state;
            CurrentState.StateEnter();
        }

        public void OneMoreEnter(IState state)
        {
            if (CurrentState != state) return;
            CurrentState.StateEnter();
        }
    }
}
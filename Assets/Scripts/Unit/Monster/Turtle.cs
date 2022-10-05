using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Turtle : Monster, IRushable
{
    public enum TurtlePhase
    {
        Attack1 = 0,
        Attack2,
        Defend
    }

    private TurtlePhase currentPhase;
    private bool isRush;

    private void Awake()
    {
        isRush = false;
        Initialize();
    }

    private void Update()
    {
        StateMachine.StateUpdate();
    }

    override public void Initialize()
    {
        base.Initialize();

        dicMonsterState = new Dictionary<NS_Unit.BaseState, IState>();
        dicMonsterState.Add(NS_Unit.BaseState.Idle, new NS_State.Idle(this));
        dicMonsterState.Add(NS_Unit.BaseState.Walk, new NS_State.Walk(this));
        dicMonsterState.Add(NS_Unit.BaseState.Run, new NS_State.Run(this));
        dicMonsterState.Add(NS_Unit.BaseState.Attack, new NS_State.Attack(this));
        dicMonsterState.Add(NS_Unit.BaseState.Defend, new NS_State.Defend(this));
        dicMonsterState.Add(NS_Unit.BaseState.Die, new NS_State.Die(this));
        StateMachine = new NS_State.State(dicMonsterState[NS_Unit.BaseState.Idle]);

        moveSpeed = 1f;
        rotateSpeed = 100f;
        rotateTime = 0;
        comboCount = 0;
    }

    public bool GetIsRush() { return isRush; }

    public void OnRush()
    {
        isRush = true;
    }
}

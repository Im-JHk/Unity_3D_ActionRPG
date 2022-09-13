using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Slime : Monster
{
    public enum SlimePhase
    {
        Attack1 = 0,
        Attack2
    }

    private SlimePhase currentPhase;

    private void Awake()
    {
        monsterPhase = new NS_Phase.BattlePhase(Enum.GetValues(typeof(SlimePhase)).Length);
        monsterNavAgent = GetComponent<NavMeshAgent>();
        rigidbody = GetComponent<Rigidbody>();
        animationEvent = new AnimationEvent();
        bodyCollider = GetComponentInChildren<CapsuleCollider>();
        animator = GetComponent<Animator>();
        Initialize();
    }

    private void Update()
    {
        StateMachine.StateUpdate();
        monsterPhase.PhaseUpdate();
    }

    override public void Initialize()
    {
        dicMonsterState = new Dictionary<NS_Unit.BaseState, IState>();
        dicMonsterState.Add(NS_Unit.BaseState.Idle, new NS_State.Idle(this));
        dicMonsterState.Add(NS_Unit.BaseState.Walk, new NS_State.Walk(this));
        dicMonsterState.Add(NS_Unit.BaseState.Run, new NS_State.Run(this));
        dicMonsterState.Add(NS_Unit.BaseState.Attack, new NS_State.Attack(this));
        dicMonsterState.Add(NS_Unit.BaseState.Die, new NS_State.Die(this));
        StateMachine = new NS_State.State(dicMonsterState[NS_Unit.BaseState.Idle]);

        monsterPhase.ListMonsterPhase.Add(new NS_Phase.MeleeAttack(this));
        monsterPhase.ListMonsterPhase.Add(new NS_Phase.MeleeAttack(this));
        monsterPhase.SetPhase(monsterPhase.ListMonsterPhase[monsterPhase.CurrentPhaseIndex]);

        canAttack = false;

        unitType = NS_Unit.UnitType.Monster;
        moveVector = Vector3.zero;
        moveSpeed = 1f;
        rotateSpeed = 100f;
        rotateTime = 0;
        comboCount = 0;
        comboMax = 2;
        isMove = false;
        isRun = false;
        canChangeState = true;
    }
}

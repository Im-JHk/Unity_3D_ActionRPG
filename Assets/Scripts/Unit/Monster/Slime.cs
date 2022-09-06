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
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
        monsterNavAgent = GetComponent<NavMeshAgent>();
        Initialize();
    }

    private void Update()
    {
        monsterState.StateUpdate();
        monsterPhase.PhaseUpdate();
    }

    override public void Initialize()
    {
        dicMonsterState = new Dictionary<NS_Unit.BaseState, IState>();
        dicMonsterState.Add(NS_Unit.BaseState.Idle, new NS_State.Idle(this));
        dicMonsterState.Add(NS_Unit.BaseState.Walk, new NS_State.Walk(this));
        dicMonsterState.Add(NS_Unit.BaseState.Run, new NS_State.Run(this));
        dicMonsterState.Add(NS_Unit.BaseState.Attack, new NS_State.Attack(this));
        monsterState = new NS_State.State(dicMonsterState[NS_Unit.BaseState.Idle]);

        listMonsterPhase = new List<IBattlePhase>();
        listMonsterPhase.Add(new NS_Phase.MeleeAttack(this));
        listMonsterPhase.Add(new NS_Phase.MeleeAttack(this));
        monsterPhase = new NS_Phase.BattlePhase(sizeof(SlimePhase));

        canAttack = false;

        unitType = NS_Unit.UnitType.Monster;
        moveVector = Vector3.zero;
        moveSpeed = 1f;
        rotateSpeed = 100f;
        rotateTime = 0;
        comboCount = 0;
        isMove = false;
        isRun = false;
        canChangeState = true;
    }
}

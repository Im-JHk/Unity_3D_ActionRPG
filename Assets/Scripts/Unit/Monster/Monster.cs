using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.AI;

public class Monster : Unit
{
    protected Dictionary<NS_Unit.BaseState, IState> dicMonsterState;
    protected NS_State.State monsterState = null;

    protected NS_Phase.BattlePhase monsterPhase = null;
    protected bool isStayCoroutine = false;

    protected NavMeshAgent monsterNavAgent = null;
    protected GameObject target = null;

    protected Vector3 dodgeDirection = Vector3.zero;
    protected float dodgeSpeed;
    protected bool canAttack;

    #region properties
    public Dictionary<NS_Unit.BaseState, IState> DicMonsterState { get { return dicMonsterState; } }
    public NS_State.State MonsterState { get { return monsterState; } set { monsterState = value; } }

    public NS_Phase.BattlePhase MonsterPhase { get { return monsterPhase; } set { monsterPhase = value; } }
    public bool IsStayCoroutine { get { return isStayCoroutine; } set { isStayCoroutine = value; } }

    public Vector3 DodgeDirection { get { return dodgeDirection; } set { dodgeDirection = value; } }
    public bool CanAttack { get { return canAttack; } set { canAttack = value; } }
    #endregion

    virtual public void Initialize()
    {
        dicMonsterState = new Dictionary<NS_Unit.BaseState, IState>();
        dicMonsterState.Add(NS_Unit.BaseState.Idle, new NS_State.Idle(this));
        dicMonsterState.Add(NS_Unit.BaseState.Walk, new NS_State.Walk(this));
        dicMonsterState.Add(NS_Unit.BaseState.Run, new NS_State.Run(this));
        dicMonsterState.Add(NS_Unit.BaseState.Attack, new NS_State.Attack(this));
        dicMonsterState.Add(NS_Unit.BaseState.Defend, new NS_State.Defend(this));
        dicMonsterState.Add(NS_Unit.BaseState.Dodge, new NS_State.Dodge(this));

        monsterState = new NS_State.State(dicMonsterState[NS_Unit.BaseState.Idle]);

        moveVector = Vector3.zero;
        moveSpeed = 1f;
        rotateSpeed = 100f;
        rotateTime = 0;
        comboCount = 0;
        isMove = false;
        isRun = false;
        canChangeState = true;
    }

    public void FocusTarget(GameObject obj)
    {
        if(this.target == null)
        {
            this.target = obj;
        }
        else
        {
            if(Utility.CompareDistance(this.transform.position, this.target.transform.position, obj.transform.position))
            {
                this.target = obj;
            }
        }
        animationEvent.GetAnimator.SetBool("IsFocus", true);
    }

    public void TargettingOff()
    {
        this.target = null;
        animationEvent.GetAnimator.SetBool("IsFocus", false);
    }

    public void SetStopDistance(float distance)
    {
        monsterNavAgent.stoppingDistance = distance;
    }

    public void ChangeMoveAndAttackState(bool b)
    {
        monsterNavAgent.isStopped = b;
        canAttack = b;
        animationEvent.GetAnimator.SetBool("CanAttack", b);
    }

    override public void Move()
    {
        monsterNavAgent.SetDestination(this.target.transform.position);
        animationEvent.GetAnimator.SetTrigger("OnMove");
    }

    override public void Attack()
    {
        animationEvent.GetAnimator.SetInteger("Combo", comboCount);
        animationEvent.GetAnimator.SetTrigger("OnAttack");
        if (comboCount >= comboMax) comboCount = 0;
        else comboCount += 1;
    }

    public IEnumerator MeleeAttack()
    {
        isStayCoroutine = true;
        while(!canAttack)
        {
            monsterState.SetState(dicMonsterState[NS_Unit.BaseState.Run]);
            yield return new WaitForSeconds(0.5f);
        }
        monsterState.SetState(dicMonsterState[NS_Unit.BaseState.Attack]);

        while (!animationEvent.IsOverPlaytime("MeleeAttack"))
        {
            yield return null;
        }
        monsterState.SetState(dicMonsterState[NS_Unit.BaseState.Idle]);
        monsterPhase.PhaseExit();

        isStayCoroutine = false;
    }

    public IEnumerator Defend(Action action)
    {
        action();

        yield break;
    }
}

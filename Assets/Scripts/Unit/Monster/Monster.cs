using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.AI;

public class Monster : Unit
{
    protected Dictionary<NS_Unit.BaseState, IState> dicMonsterState;

    protected NS_Phase.BattlePhase monsterPhase = null;
    protected bool isStayCoroutine = false;

    protected NavMeshAgent monsterNavAgent = null;
    protected GameObject target = null;
    protected MonsterStat monsterStat = null;

    protected Vector3 dodgeDirection = Vector3.zero;
    protected bool canAttack;

    private WaitForSeconds WaitOneSeconds = new WaitForSeconds(1f);
    private WaitForSeconds WaitTwoSeconds = new WaitForSeconds(2f);

    #region properties
    public Dictionary<NS_Unit.BaseState, IState> DicMonsterState { get { return dicMonsterState; } }

    public NS_Phase.BattlePhase MonsterPhase { get { return monsterPhase; } set { monsterPhase = value; } }
    public bool IsStayCoroutine { get { return isStayCoroutine; } set { isStayCoroutine = value; } }

    public Vector3 DodgeDirection { get { return dodgeDirection; } set { dodgeDirection = value; } }
    public bool CanAttack { get { return canAttack; } set { canAttack = value; } }
    #endregion

    virtual public void Initialize() { }

    #region SetNav
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
        animator.SetBool(HashIsFocus, true);
    }

    public void TargettingOff()
    {
        this.target = null;
        animator.SetBool(HashIsFocus, false);
    }

    public void SetStopDistance(float distance)
    {
        monsterNavAgent.stoppingDistance = distance;
    }

    public void ChangeMoveAndAttackState(bool b)
    {
        print(b);
        monsterNavAgent.isStopped = b;
        canAttack = b;
        animator.SetBool(HashCanAttack, b);
    }
    #endregion

    #region State Function
    // -- override --
    override public void Move()
    {
        if (this.target == null)
        {
            //Search
        }
        else
        {
            if (!isStayCoroutine && !isMove) StartCoroutine(nameof(ChaseTarget));
        }
    }

    override public void Attack()
    {
        if (!isStayCoroutine && !isAttack) StartCoroutine(nameof(MeleeAttack));
    }

    override public void Damaged(float damage, Vector3 hitDir, Vector3 hitPoint)
    {
        animator.SetTrigger(HashOnHit);
        if (monsterStat.Damaged(damage))
        {
            StateMachine.SetState(dicMonsterState[NS_Unit.BaseState.Die]);
            StartCoroutine(nameof(DestroyMonster));
        }
    }

    override public void SetMoveParameter()
    {
        //
    }

    // -- Coroutine --
    public IEnumerator ChaseTarget()
    {
        isStayCoroutine = true;

        print("chase in");

        isRun = true;
        animator.SetBool(HashIsRun, isRun);

        while (!canAttack && Vector3.Distance(this.transform.position, this.target.transform.position) > monsterNavAgent.stoppingDistance)
        {
            yield return WaitOneSeconds;
            if (monsterNavAgent.isStopped) animator.SetBool(HashIsRun, false);

            if (this.target == null) break;
            else
            {
                monsterNavAgent.SetDestination(this.target.transform.position);
                monsterNavAgent.stoppingDistance = this.target.transform.lossyScale.z;
                animator.SetBool(HashIsRun, true);
            }
        }

        //canAttack = true;
        isRun = false;
        animator.SetBool(HashIsRun, isRun);

        isStayCoroutine = false;
        print("chase out");

        StateMachine.SetState(dicMonsterState[NS_Unit.BaseState.Attack]);
    }

    public IEnumerator MeleeAttack()
    {
        isStayCoroutine = true;
        print("meleeAttack in");

        isAttack = true;

        while (isAttack && canAttack)
        {
            animator.SetBool(HashIsAttack, false);
            yield return WaitTwoSeconds;
            animator.SetBool(HashIsAttack, true);
            yield return WaitOneSeconds;
        }

        isAttack = false;
        animator.SetBool(HashIsAttack, isAttack);
        StateMachine.SetState(dicMonsterState[NS_Unit.BaseState.Idle]);

        isStayCoroutine = false;
        print("meleeAttack out");
    }

    public IEnumerator Defend(Action action)
    {
        action();

        yield break;
    }

    public IEnumerator DestroyMonster()
    {
        StopCoroutine(nameof(MeleeAttack));
        yield return new WaitForSeconds(2f);

        this.gameObject.SetActive(false);
    }
    #endregion

    #region AnimationEvent
    override public void OnEventSetMoveState()
    {
        StateMachine.SetState(dicMonsterState[NS_Unit.BaseState.Idle]);
    }

    public void OnEventSetAttackState()
    {
        StateMachine.SetState(dicMonsterState[NS_Unit.BaseState.Idle]);
    }

    #endregion
}

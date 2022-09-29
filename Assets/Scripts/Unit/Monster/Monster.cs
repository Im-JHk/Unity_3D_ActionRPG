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
    [SerializeField]
    protected MonsterAttackHit monsterHit = null;

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

    virtual public void Initialize() 
    {
        monsterNavAgent = GetComponent<NavMeshAgent>();
        monsterStat = GetComponent<MonsterStat>();
        rigidbody = GetComponent<Rigidbody>();
        animationEvent = new AnimationEvent();
        bodyCollider = GetComponentInChildren<CapsuleCollider>();
        animator = GetComponent<Animator>();

        unitType = NS_Unit.UnitType.Monster;
        moveVector = Vector3.zero;
        isMove = false;
        isRun = false;
        canAttack = false;
        canChangeState = true;
    }

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

        isRun = true;
        animator.SetBool(HashIsRun, isRun);

        while (!canAttack && Vector3.Distance(this.transform.position, this.target.transform.position) > monsterNavAgent.stoppingDistance)
        {
            yield return WaitOneSeconds;

            if (this.target == null || monsterNavAgent.isStopped) break;
            else
            {
                monsterNavAgent.SetDestination(this.target.transform.position);
                monsterNavAgent.stoppingDistance = this.target.transform.lossyScale.z;
                animator.SetBool(HashIsRun, true);
            }
        }

        isRun = false;
        animator.SetBool(HashIsRun, isRun);

        isStayCoroutine = false;

        StateMachine.SetState(dicMonsterState[NS_Unit.BaseState.Attack]);
    }

    public IEnumerator MeleeAttack()
    {
        isStayCoroutine = true;
        isAttack = true;

        while (isAttack && canAttack)
        {
            animator.SetTrigger(HashOnAttack);
            yield return WaitTwoSeconds;
        }
        isAttack = false;
        isStayCoroutine = false;

        if (target == null) StateMachine.SetState(dicMonsterState[NS_Unit.BaseState.Idle]);
        else StateMachine.SetState(dicMonsterState[NS_Unit.BaseState.Run]);
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

    virtual public void OnEventSetHitbox(TrueFalse tf)
    {

    }

    #endregion
}

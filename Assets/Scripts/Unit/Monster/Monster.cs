using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster : Unit
{
    protected Dictionary<BaseState, IState> dicMonsterState;
    protected State monsterState = null;
    protected NavMeshAgent monsterNavAgent = null;
    protected GameObject target = null;

    protected Vector3 dodgeDirection = Vector3.zero;
    protected float dodgeSpeed;
    protected float phaseTime;
    protected float phaseDelay;
    protected bool canAttack;

    #region properties
    public Dictionary<BaseState, IState> DicMonsterState { get { return dicMonsterState; } }
    public State MonsterState { get { return monsterState; } set { monsterState = value; } }
    public Vector3 DodgeDirection { get { return dodgeDirection; } set { dodgeDirection = value; } }
    #endregion

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
        monsterNavAgent = GetComponent<NavMeshAgent>();
        unitType = UnitType.Monster;
        phaseTime = 0;
        phaseDelay = 1f;
        canAttack = false;
        Initialize();
    }

    private void Update()
    {
        monsterState.Update();
    }

    virtual public void Initialize()
    {
        dicMonsterState = new Dictionary<BaseState, IState>();
        dicMonsterState.Add(BaseState.Idle, new Idle(this));
        dicMonsterState.Add(BaseState.Walk, new Walk(this));
        dicMonsterState.Add(BaseState.Run, new Run(this));
        dicMonsterState.Add(BaseState.Attack, new Attack(this));
        dicMonsterState.Add(BaseState.Defend, new Defend(this));
        dicMonsterState.Add(BaseState.Dodge, new Dodge(this));

        monsterState = new State(dicMonsterState[BaseState.Idle]);

        moveVector = Vector3.zero;
        moveSpeed = 1f;
        rotateSpeed = 100f;
        rotateTime = 0;
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
        animator.SetBool("IsFocus", true);
    }

    public void TargettingOff()
    {
        this.target = null;
        animator.SetBool("IsFocus", false);
    }

    public void SetStopDistance(float distance)
    {
        monsterNavAgent.stoppingDistance = distance;
        print("SetStopDistance: " + monsterNavAgent.stoppingDistance);
    }

    public void ChangeMoveAndAttackState(bool b)
    {
        print("ChangeMoveAndAttackState: " + b);
        monsterNavAgent.isStopped = b;
        phaseTime = 0;
        canAttack = b;
        animator.SetBool("CanAttack", b);
    }

    override public void Move()
    {
        monsterNavAgent.SetDestination(this.target.transform.position);
        animator.SetTrigger("OnMove");
    }

    override public void Attack()
    {
        print("mons attack");
        animator.SetTrigger("OnAttack");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster : Unit
{
    private Dictionary<BaseState, IState> dicMonsterState;
    private State mosterState = null;
    private NavMeshAgent monsterNavAgent = null;
    private GameObject target = null;

    private Vector3 dodgeDirection = Vector3.zero;
    private float dodgeSpeed;
    private bool canAttack;

    #region properties
    public Dictionary<BaseState, IState> DicMonsterState { get { return dicMonsterState; } }
    public State MonsterState { get { return mosterState; } set { mosterState = value; } }
    public Vector3 DodgeDirection { get { return dodgeDirection; } set { dodgeDirection = value; } }
    #endregion

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
        monsterNavAgent.GetComponent<NavMeshAgent>();
        unitType = UnitType.Player;
        canAttack = false;
        Initialize();
    }

    void Update()
    {
        
    }

    private void Initialize()
    {
        dicMonsterState = new Dictionary<BaseState, IState>();
        dicMonsterState.Add(BaseState.Idle, new Idle(this));
        dicMonsterState.Add(BaseState.Walk, new Walk(this));
        dicMonsterState.Add(BaseState.Run, new Run(this));
        dicMonsterState.Add(BaseState.Attack, new Attack(this));
        dicMonsterState.Add(BaseState.Defend, new Defend(this));
        dicMonsterState.Add(BaseState.Dodge, new Dodge(this));

        MonsterState = new State(dicMonsterState[BaseState.Idle]);

        moveVector = Vector3.zero;
        moveSpeed = 3f;
        rotateSpeed = 50f;
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
    }

    public void TargettingOff()
    {
        this.target = null;
    }

    public void SetStopDistance(float distance)
    {
        monsterNavAgent.stoppingDistance = distance;
    }

    public void ChangeMoveAndAttackState(bool b)
    {
        monsterNavAgent.isStopped = b;
        canAttack = b;
        animator.SetBool("CanAttack", b);
    }

    override public void Move()
    {
        print("mons move");
        monsterNavAgent.SetDestination(this.target.transform.position);
        animator.SetTrigger("OnMove");
    }

    override public void Attack()
    {
        print("mons attack");
        animator.SetTrigger("OnAttack");
    }
}

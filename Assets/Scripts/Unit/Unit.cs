using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : MonoBehaviour, IMovable, IBattle
{
    protected AnimationEvent animationEvent = null;
    protected Animator animator = null;
    protected Rigidbody rigidbody = null;
    [SerializeField]
    protected CapsuleCollider bodyCollider = null;
    protected SkinnedMeshRenderer meshRenderer = null;
    protected Color originColor;

    protected Dictionary<NS_Unit.BaseState, IState> dicState;
    protected NS_State.State stateMachine;
    protected NS_Unit.UnitType unitType;
    protected NS_Unit.MoveState currentMoveState = NS_Unit.MoveState.None;
    protected NS_Unit.ActionState currentActionState = NS_Unit.ActionState.None;

    protected float hp;

    [SerializeField]
    protected Vector3 moveVector;
    protected float moveSpeed;
    protected float rotateSpeed;
    protected float rotateTime;
    protected float dodgeSpeed;
    protected int comboCount;
    protected int comboMax;
    protected bool isMove;
    protected bool isRun;
    protected bool isAttack;
    protected bool isDefend;
    protected bool isDodge;
    protected bool canChangeState;
    protected bool canComboAttack;

    public readonly int HashHorizontal = Animator.StringToHash("Horizontal");
    public readonly int HashVertical = Animator.StringToHash("Vertical");
    public readonly int HashMoveSpeed = Animator.StringToHash("MoveSpeed");
    public readonly int HashIsMove = Animator.StringToHash("IsMove");
    public readonly int HashIsRun = Animator.StringToHash("IsRun");
    public readonly int HashOnAttack = Animator.StringToHash("OnAttack");
    public readonly int HashIsAttack = Animator.StringToHash("IsAttack");
    public readonly int HashCanAttack = Animator.StringToHash("CanAttack");
    public readonly int HashCombo = Animator.StringToHash("AttackCombo");
    public readonly int HashIsDefend = Animator.StringToHash("IsDefend");
    public readonly int HashOnDodge = Animator.StringToHash("OnDodge");
    public readonly int HashIsFocus = Animator.StringToHash("IsFocus");
    public readonly int HashIsDie = Animator.StringToHash("IsDie");
    public readonly int HashOnHit = Animator.StringToHash("OnHit");

    #region properties
    public AnimationEvent AnimationEvent { get { return animationEvent; } }
    public Animator Animator { get { return animator; } }
    public Rigidbody Rigidbody { get { return rigidbody; } }
    public CapsuleCollider BodyCollider { get { return bodyCollider; } }

    public Dictionary<NS_Unit.BaseState, IState> DicState { get { return dicState; } protected set { dicState = value; } }
    public NS_State.State StateMachine { get { return stateMachine; } protected set { stateMachine = value; } }
    public NS_Unit.UnitType UnitType { get { return unitType; } }
    public NS_Unit.MoveState MoveState { get { return currentMoveState; } set { currentMoveState = value; } }
    public NS_Unit.ActionState ActionState { get { return currentActionState; } set { currentActionState = value; } }

    public Vector3 MoveVector { get { return moveVector; } set { moveVector = value; } }
    public float MoveSpeed { get { return moveSpeed; } set { moveSpeed = value; } }
    public float RotateSpeed { get { return rotateSpeed; } set { rotateSpeed = value; } }
    public float RotateTime { get { return rotateTime; } set { rotateTime = value; } }
    public bool IsMove { get { return isMove; } set { isMove = value; } }
    public bool IsRun { get { return isRun; } set { isRun = value; } }
    public bool IsAttack { get { return isAttack; } set { isAttack = value; } }
    public bool IsDefend { get { return isDefend; } set { isDefend = value; } }
    public bool IsDodge { get { return isDodge; } set { isDodge = value; } }
    public bool CanChangeState { get { return canChangeState; } set { canChangeState = value; } }
    public bool CanComboAttack { get { return canComboAttack; } set { canComboAttack = value; } }
    #endregion

    virtual public void Move()
    {
        Debug.Log("base Move()");
    }

    virtual public void Rotate()
    {
        Debug.Log("base Rotate()");
    }

    virtual public void Attack()
    {
        Debug.Log("base Attack()");
    }
    
    virtual public void Defend()
    {
        Debug.Log("base Defend()");
    }

    virtual public void Damaged(float damage, Vector3 hitDir, Vector3 hitPoint)
    {
        Debug.Log("base Damaged()");
    }

    virtual public void Dodge()
    {
        Debug.Log("base Dodge()");
    }

    virtual public void SetMoveParameter() { }

    virtual public void OnEventSetMoveState() { }
}

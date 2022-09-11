using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : MonoBehaviour, IMovable, IBattle
{
    protected AnimationEvent animationEvent = null;
    protected Animator anim = null;
    protected Rigidbody rigidbody = null;

    protected NS_Unit.UnitType unitType;
    protected NS_Unit.MoveState currentMoveState = NS_Unit.MoveState.None;
    protected NS_Unit.ActionState currentActionState = NS_Unit.ActionState.None;
    [SerializeField]
    protected Vector3 moveVector;
    [SerializeField]
    protected Vector3 lookVector;
    [SerializeField]
    protected float moveSpeed;
    protected float rotateSpeed;
    protected float rotateTime;
    protected int comboCount;
    protected int comboMax;
    protected bool isMove;
    protected bool isRun;
    protected bool isAttack;
    protected bool isDefend;
    protected bool isDodge;
    protected bool canChangeState;

    #region properties
    public AnimationEvent GetAnimationEvent { get { return animationEvent; } }
    public Animator Anim { get { return anim; } set { anim = value; } }
    public Rigidbody GetRigidbody { get { return rigidbody; } }
    public NS_Unit.UnitType UnitType { get { return unitType; } }
    public NS_Unit.MoveState MoveState { get { return currentMoveState; } set { currentMoveState = value; } }
    public NS_Unit.ActionState ActionState { get { return currentActionState; } set { currentActionState = value; } }
    public Vector3 MoveVector { get { return moveVector; } set { moveVector = value; } }
    public Vector3 LookVector { get { return lookVector; } set { lookVector = value; } }
    public float MoveSpeed { get { return moveSpeed; } set { moveSpeed = value; } }
    public float RotateSpeed { get { return rotateSpeed; } set { rotateSpeed = value; } }
    public float RotateTime { get { return rotateTime; } set { rotateTime = value; } }
    public bool IsMove { get { return isMove; } set { isMove = value; } }
    public bool IsRun { get { return isRun; } set { isRun = value; } }
    public bool IsAttack { get { return isAttack; } set { isAttack = value; } }
    public bool IsDefend { get { return isDefend; } set { isDefend = value; } }
    public bool IsDodge { get { return isDodge; } set { isDodge = value; } }
    public bool CanChangeState { get { return canChangeState; } set { canChangeState = value; } }
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

    virtual public void Damaged()
    {
        Debug.Log("base Damaged()");
    }

    virtual public void Dodge()
    {
        Debug.Log("base Dodge()");
    }

    virtual public void SetMoveParameter() { }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : MonoBehaviour, IMovable, IBattle
{
    public enum UnitType
    {
        Player = 0,
        Monster
    }
    public enum AnimatorLayer
    {
        Base = 0,
        Blend,
        Single
    }
    public enum MoveState
    {
        None = 0,
        Idle,
        Walk,
        Run
    }
    public enum ActionState
    {
        None = 0,
        Attack,
        Defend,
        Dodge
    }

    protected Animator animator = null;
    protected Rigidbody rigidbody = null;
    protected UnitType unitType;
    protected MoveState currentMoveState = MoveState.None;
    protected ActionState currentActionState = ActionState.None;
    protected Vector3 moveVector;
    protected Vector3 lookVector;
    protected float moveSpeed;
    protected float rotateSpeed;
    protected float rotateTime;
    protected bool isMove;
    protected bool isRun;
    protected bool isAttack;
    protected bool isDefend;
    protected bool isDodge;
    protected bool canChangeState;

    #region properties
    public Animator GetAnimator { get { return animator; } }
    public Rigidbody GetRigidbody { get { return rigidbody; } }
    public UnitType GetUnitType { get { return unitType; } }
    public MoveState GetMoveState { get { return currentMoveState; } set { currentMoveState = value; } }
    public ActionState GetActionState { get { return currentActionState; } set { currentActionState = value; } }
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
}

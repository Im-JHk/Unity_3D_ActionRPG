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

    protected Animator animator = null;
    protected Rigidbody rigidbody = null;
    protected UnitType unitType;
    protected Vector3 moveVector;
    protected float moveSpeed;
    protected float rotateSpeed;
    protected float rotateTime;
    protected bool isMove;
    protected bool isRun;
    protected bool canChangeState;

    #region properties
    public Animator GetAnimator { get { return animator; } }
    public Rigidbody GetRigidbody { get { return rigidbody; } }
    public UnitType GetUnitType { get { return unitType; } }
    public Vector3 MoveVector { get { return moveVector; } set { moveVector = value; } }
    public float MoveSpeed { get { return moveSpeed; } set { moveSpeed = value; } }
    public float RotateSpeed { get { return rotateSpeed; } set { rotateSpeed = value; } }
    public float RotateTime { get { return rotateTime; } set { rotateTime = value; } }
    public bool IsMove { get { return isMove; } set { isMove = value; } }
    public bool IsRun { get { return isRun; } set { isRun = value; } }
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

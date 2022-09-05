using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Unit
{
    private Dictionary<BaseState, IState> dicPlayerState;
    private State playerState = null;
    private float dodgeSpeed = 6f;
    private Vector3 dodgeDirection = Vector3.zero;

    #region properties
    public Dictionary<BaseState, IState> GetDicPlayerState { get { return dicPlayerState; } }
    public State GetPlayerState { get { return playerState; } set { playerState = value; } }
    public Vector3 DodgeDirection { get { return dodgeDirection; } set { dodgeDirection = value; } }
    #endregion

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
        unitType = UnitType.Player;
        Initialize();
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        playerState.Update();
    }

    public void Initialize()
    {
        dicPlayerState = new Dictionary<BaseState, IState>();
        dicPlayerState.Add(BaseState.Idle, new Idle(this));
        dicPlayerState.Add(BaseState.Walk, new Walk(this));
        dicPlayerState.Add(BaseState.Run, new Run(this));
        dicPlayerState.Add(BaseState.Attack, new Attack(this));
        dicPlayerState.Add(BaseState.Defend, new Defend(this));
        dicPlayerState.Add(BaseState.Dodge, new Dodge(this));

        playerState = new State(dicPlayerState[Unit.BaseState.Idle]);

        moveVector = Vector3.zero;
        moveSpeed = 3f;
        rotateSpeed = 50f;
        rotateTime = 0;
        isMove = false;
        isRun = false;
        canChangeState = true;
    }

    override public void Move()
    {
        SetMoveParameter();
        if (moveVector != Vector3.zero && currentActionState == ActionState.None)
        {
            rigidbody.MovePosition(rigidbody.position + moveVector * moveSpeed * Time.deltaTime);
            Rotate();
        }
    }

    override public void Rotate()
    {
        var rotation = Quaternion.LookRotation(moveVector);
        transform.rotation = Quaternion.Slerp(rigidbody.rotation, rotation, rotateSpeed * Time.deltaTime);
    }

    override public void Attack()
    {
        base.Attack();
    }

    override public void Defend()
    {
        base.Defend();
    }

    override public void Damaged()
    {
        base.Damaged();
    }

    override public void Dodge()
    {
        if(moveVector == Vector3.zero)
        {
            dodgeDirection = lookVector;
        }
        else
        {
            dodgeDirection = moveVector;
        }

        if (animator.GetCurrentAnimatorStateInfo((int)AnimatorLayer.Single).normalizedTime >= 0.9)
        {
            canChangeState = true;
            if (isMove) playerState.SetState(dicPlayerState[BaseState.Walk]);
            else if (isRun) playerState.SetState(dicPlayerState[BaseState.Run]);
            else playerState.SetState(dicPlayerState[BaseState.Idle]);
        }
        else if (animator.GetCurrentAnimatorStateInfo((int)AnimatorLayer.Single).normalizedTime >= 0.15)
        {
            rigidbody.MovePosition(rigidbody.position + dodgeDirection * dodgeSpeed * Time.deltaTime);
        }
    }

    public void SetMoveParameter()
    {
        animator.SetFloat("Horizontal", moveVector.x);
        animator.SetFloat("Vertical", moveVector.z);
        animator.SetBool("IsMove", isMove);
        animator.SetBool("IsRun", isRun);
        if (moveVector == Vector3.zero) animator.SetFloat("MoveSpeed", 0);
        else animator.SetFloat("MoveSpeed", moveSpeed);
    }
}

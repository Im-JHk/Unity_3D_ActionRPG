using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Unit
{
    private Dictionary<NS_Unit.BaseState, IState> dicPlayerState;
    private NS_State.State playerState = null;
    private float dodgeSpeed = 6f;
    private Vector3 dodgeDirection = Vector3.zero;

    #region properties
    public Dictionary<NS_Unit.BaseState, IState> GetDicPlayerState { get { return dicPlayerState; } }
    public NS_State.State GetPlayerState { get { return playerState; } set { playerState = value; } }
    public Vector3 DodgeDirection { get { return dodgeDirection; } set { dodgeDirection = value; } }
    #endregion

    private void Awake()
    {
        animationEvent = new AnimationEvent(GetComponent<Animator>());
        rigidbody = GetComponent<Rigidbody>();
        unitType = NS_Unit.UnitType.Player;
        Initialize();
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        playerState.StateUpdate();
    }

    public void Initialize()
    {
        dicPlayerState = new Dictionary<NS_Unit.BaseState, IState>();
        dicPlayerState.Add(NS_Unit.BaseState.Idle, new NS_State.Idle(this));
        dicPlayerState.Add(NS_Unit.BaseState.Walk, new NS_State.Walk(this));
        dicPlayerState.Add(NS_Unit.BaseState.Run, new NS_State.Run(this));
        dicPlayerState.Add(NS_Unit.BaseState.Attack, new NS_State.Attack(this));
        dicPlayerState.Add(NS_Unit.BaseState.Defend, new NS_State.Defend(this));
        dicPlayerState.Add(NS_Unit.BaseState.Dodge, new NS_State.Dodge(this));

        playerState = new NS_State.State(dicPlayerState[NS_Unit.BaseState.Idle]);

        moveVector = Vector3.zero;
        moveSpeed = 3f;
        rotateSpeed = 50f;
        rotateTime = 0;
        comboCount = 0;
        isMove = false;
        isRun = false;
        canChangeState = true;
    }

    override public void Move()
    {
        SetMoveParameter();
        if (moveVector != Vector3.zero && currentActionState == NS_Unit.ActionState.None)
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

        if (animationEvent.GetAnimator.GetCurrentAnimatorStateInfo((int)NS_Unit.AnimatorLayer.Single).normalizedTime >= 0.9)
        {
            canChangeState = true;
            if (isMove) playerState.SetState(dicPlayerState[NS_Unit.BaseState.Walk]);
            else if (isRun) playerState.SetState(dicPlayerState[NS_Unit.BaseState.Run]);
            else playerState.SetState(dicPlayerState[NS_Unit.BaseState.Idle]);
        }
        else if (animationEvent.GetAnimator.GetCurrentAnimatorStateInfo((int)NS_Unit.AnimatorLayer.Single).normalizedTime >= 0.15)
        {
            rigidbody.MovePosition(rigidbody.position + dodgeDirection * dodgeSpeed * Time.deltaTime);
        }
    }

    public void SetMoveParameter()
    {
        animationEvent.GetAnimator.SetFloat("Horizontal", moveVector.x);
        animationEvent.GetAnimator.SetFloat("Vertical", moveVector.z);
        animationEvent.GetAnimator.SetBool("IsMove", isMove);
        animationEvent.GetAnimator.SetBool("IsRun", isRun);
        if (moveVector == Vector3.zero) animationEvent.GetAnimator.SetFloat("MoveSpeed", 0);
        else animationEvent.GetAnimator.SetFloat("MoveSpeed", moveSpeed);
    }
}

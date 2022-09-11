using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Unit
{
    private Dictionary<NS_Unit.BaseState, IState> dicPlayerState;
    private float dodgeSpeed = 0.5f;

    #region properties
    public Dictionary<NS_Unit.BaseState, IState> DicPlayerState { get { return dicPlayerState; } }
    public NS_State.State StateMachine { get; set; }
    public Vector3 DodgeDirection { get; set; }
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
        StateMachine.StateUpdate();
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

        StateMachine = new NS_State.State(dicPlayerState[NS_Unit.BaseState.Idle]);

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
        if (moveVector != Vector3.zero && isMove && currentActionState == NS_Unit.ActionState.None)
        {
            rigidbody.MovePosition(rigidbody.position + moveVector * moveSpeed * Time.deltaTime);
            //if()
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
        print("tfor: " + transform.forward);
        rigidbody.AddForce(transform.forward * dodgeSpeed, ForceMode.Impulse);
        if (animationEvent.GetAnimator.GetCurrentAnimatorStateInfo((int)NS_Unit.AnimatorLayer.Base).IsTag("Dodge"))
        {
            //rigidbody.MovePosition(rigidbody.position + moveVector * dodgeSpeed * Time.deltaTime);
            
            if (animationEvent.GetAnimator.GetCurrentAnimatorStateInfo((int)NS_Unit.AnimatorLayer.Base).normalizedTime >= 0.7)
            {
                if (isMove) StateMachine.SetState(dicPlayerState[NS_Unit.BaseState.Walk]);
                else if (isRun) StateMachine.SetState(dicPlayerState[NS_Unit.BaseState.Run]);
                else StateMachine.SetState(dicPlayerState[NS_Unit.BaseState.Idle]);
            }
        }
        else
        {
            if (isMove) StateMachine.SetState(dicPlayerState[NS_Unit.BaseState.Walk]);
            else if (isRun) StateMachine.SetState(dicPlayerState[NS_Unit.BaseState.Run]);
            else StateMachine.SetState(dicPlayerState[NS_Unit.BaseState.Idle]);
        }
    }

    override public void SetMoveParameter()
    {
        if (moveVector == Vector3.zero)
        {
            animationEvent.GetAnimator.SetFloat("MoveSpeed", 0);
            isMove = false;
            isRun = false;
        }
        else animationEvent.GetAnimator.SetFloat("MoveSpeed", moveSpeed);
        animationEvent.GetAnimator.SetFloat("Horizontal", moveVector.x);
        animationEvent.GetAnimator.SetFloat("Vertical", moveVector.z);
        animationEvent.GetAnimator.SetBool("IsMove", isMove);
        animationEvent.GetAnimator.SetBool("IsRun", isRun);
    }
}

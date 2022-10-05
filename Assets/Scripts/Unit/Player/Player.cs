using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Unit
{
    [SerializeField]
    private PlayerStat playerStat = null;
    [SerializeField]
    private PlayerAttackHit playerhit = null;
    [SerializeField]
    private Transform spawnPosition = null;

    public void Initialize()
    {
        if (playerStat == null) playerStat = GetComponent<PlayerStat>();
        if (bodyCollider == null) bodyCollider = GetComponent<CapsuleCollider>();

        DicState = new Dictionary<NS_Unit.BaseState, IState>();
        DicState.Add(NS_Unit.BaseState.Idle, new NS_State.Idle(this));
        DicState.Add(NS_Unit.BaseState.Walk, new NS_State.Walk(this));
        DicState.Add(NS_Unit.BaseState.Run, new NS_State.Run(this));
        DicState.Add(NS_Unit.BaseState.Attack, new NS_State.Attack(this));
        DicState.Add(NS_Unit.BaseState.Defend, new NS_State.Defend(this));
        DicState.Add(NS_Unit.BaseState.Dodge, new NS_State.Dodge(this));
        DicState.Add(NS_Unit.BaseState.Die, new NS_State.Die(this));

        StateMachine = new NS_State.State(DicState[NS_Unit.BaseState.Idle]);

        moveVector = Vector3.zero;
        moveSpeed = 3f;
        dodgeSpeed = 10f;
        rotateSpeed = 50f;
        rotateTime = 0;
        comboCount = 0;
        comboMax = 4;
        isMove = false;
        isRun = false;
        isAttack = false;
        isDefend = false;
        isDodge = false;
        isDie = false;
        canChangeState = true;
        canComboAttack = true;
    }

    #region State
    // -- override --
    public override void Move()
    {
        if (moveVector != Vector3.zero && isMove && 
            (currentActionState == NS_Unit.ActionState.None || currentActionState == NS_Unit.ActionState.Defend))
        {
            rigidbody.MovePosition(rigidbody.position + moveVector * moveSpeed * Time.deltaTime);
            Rotate();
        }
    }

    public override void Rotate()
    {
        var rotation = Quaternion.LookRotation(moveVector);
        transform.rotation = Quaternion.Slerp(rigidbody.rotation, rotation, rotateSpeed * Time.deltaTime);
    }

    public override void Attack()
    {
        if (!isAttack)
        {
            isAttack = true;
            canComboAttack = false;
            comboCount = 0;
            animator.SetTrigger(HashOnAttack);
        }
        else if (canComboAttack)
        {
            if (comboCount >= comboMax - 1) comboCount = 0;
            else comboCount += 1;
            canComboAttack = false;
            animator.ResetTrigger(HashOnAttack);
            animator.SetTrigger(HashOnAttack);
        }
    }

    public override void Defend()
    {
        base.Defend();
    }

    public override void Dodge()
    {
        //Rigidbody.AddForce(transform.forward * dodgeSpeed, ForceMode.VelocityChange);
    }

    public override void Damaged(float damage, Vector3 hitDir, Vector3 hitPoint)
    {
        if (isDie) return;

        animator.SetTrigger(HashOnHit);
        if (playerStat.Damaged(damage))
        {
            StateMachine.SetState(DicState[NS_Unit.BaseState.Die]);
        }
    }

    public override void SetMoveParameter()
    {
        if (moveVector == Vector3.zero)
        {
            animator.SetFloat(HashMoveSpeed, 0);
            isMove = false;
            isRun = false;
        }
        else
        {
            animator.SetFloat(HashMoveSpeed, moveSpeed);
            isMove = true;
        }
        animator.SetFloat(HashHorizontal, moveVector.x);
        animator.SetFloat(HashVertical, moveVector.z);
        animator.SetBool(HashIsMove, isMove);
        animator.SetBool(HashIsRun, isRun);
    }
    #endregion

    #region AnimationEvent
    public override void OnEventSetMoveState()
    {
        if (isMove) StateMachine.SetState(DicState[NS_Unit.BaseState.Walk]);
        else if (isRun) StateMachine.SetState(DicState[NS_Unit.BaseState.Run]);
        else StateMachine.SetState(DicState[NS_Unit.BaseState.Idle]);
    }

    public void OnEventSetCanCombo()
    {
        canComboAttack = true;
    }

    public void OnEventSetHitbox(TrueFalse tf)
    {
        if (tf == TrueFalse.False) playerhit.Hitbox.enabled = false;
        else playerhit.Hitbox.enabled = true;
    }
    #endregion

    #region Monobehaviour
    private void Awake()
    {
        if (spawnPosition == null) spawnPosition = GameObject.FindGameObjectWithTag("PlayerSpawn").transform;
        transform.position = spawnPosition.position;

        animationEvent = new AnimationEvent();
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();

        unitType = NS_Unit.UnitType.Player;
        Initialize();

        playerhit = GetComponentInChildren<PlayerAttackHit>();
    }

    private void Update()
    {
        StateMachine.StateUpdate();
        if (StateMachine.CurrentState.IsExitReady()) StateMachine.SetState(DicState[NS_Unit.BaseState.Idle]);
    }
    #endregion
}
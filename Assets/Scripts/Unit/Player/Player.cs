using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Unit
{
    public enum PlayerState
    {
        Idle,
        Walk,
        Run,
        Attack,
        Defend,
        Dodge,
    }

    public enum PlayerMoveState
    {
        None = 0,
        Walk,
        Run
    }

    private Animator animator = null;
    private Rigidbody rigidbody = null;
    private State playerState = null;
    private Dictionary<PlayerState, IState> dicPlayerState;

    private static float moveSpeed = 3f;
    private static float rotateSpeed = 10f;

    public Animator GetAnimator { get { return animator; } }
    public Rigidbody GetRigidbody { get { return rigidbody; } }
    public State GetPlayerState { get { return playerState; } }
    public Dictionary<PlayerState, IState> GetDicPlayerState { get { return dicPlayerState; } }

    public float MoveSpeed { get { return moveSpeed; } set { moveSpeed = value; } }
    public float RotateSpeed { get { return rotateSpeed; } set { rotateSpeed = value; } }


    private void Awake()
    {
        unitType = UnitType.Player;
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        
    }

    private void Update()
    {

    }

    public void Initialize()
    {
        dicPlayerState = new Dictionary<Player.PlayerState, IState>();
        dicPlayerState.Add(Player.PlayerState.Idle, new Idle(this));
        dicPlayerState.Add(Player.PlayerState.Walk, new Walk(this));
        dicPlayerState.Add(Player.PlayerState.Run, new Run(this));
        dicPlayerState.Add(Player.PlayerState.Attack, new Attack(this));
        dicPlayerState.Add(Player.PlayerState.Defend, new Defend(this));
        dicPlayerState.Add(Player.PlayerState.Dodge, new Dodge(this));

        playerState = new State(dicPlayerState[Player.PlayerState.Idle]);

        moveVector = Vector3.zero;
        rotateTime = 0;
        isRun = false;
    }

    override public void Move()
    {
        if (moveVector != Vector3.zero)
        {
            if (isRun) moveSpeed *= 2f;
            rigidbody.MovePosition(rigidbody.position + moveVector * moveSpeed * Time.deltaTime);
        }
    }

    override public void Rotate()
    {
        if (moveVector != Vector3.zero)
        {
            var rotation = Quaternion.LookRotation(moveVector);
            transform.rotation = Quaternion.Slerp(rigidbody.rotation, rotation, rotateSpeed * Time.deltaTime);
        }
    }
}

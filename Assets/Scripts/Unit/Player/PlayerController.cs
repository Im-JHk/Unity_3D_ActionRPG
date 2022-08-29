using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour, PlayerInput.IPlayerActions
{
    private Player player = null;
    private State playerState = null;

    private Dictionary<Player.PlayerState, IState> dicPlayerState;
    private Vector3 moveVector;
    private float rotateTime;


    private bool isRun;

    private static float moveSpeed = 3f;
    private static readonly float rotateSpeed = 10f;

    void Start()
    {
        player = GetComponent<Player>();

        dicPlayerState = new Dictionary<Player.PlayerState, IState>();
        dicPlayerState.Add(Player.PlayerState.Idle, new Idle());
        dicPlayerState.Add(Player.PlayerState.Walk, new Walk());
        dicPlayerState.Add(Player.PlayerState.Run, new Run());
        dicPlayerState.Add(Player.PlayerState.Attack, new Attack());
        dicPlayerState.Add(Player.PlayerState.Defend, new Defend());
        dicPlayerState.Add(Player.PlayerState.Dodge, new Dodge());

        playerState = new State(dicPlayerState[Player.PlayerState.Idle]);

        moveVector = Vector3.zero;
        rotateTime = 0;
        isRun = false;
    }

    void Update()
    {
        if (moveVector != Vector3.zero)
        {
            Move();
            Rotate();
        }
    }

    public void Move()
    {
        if (isRun) moveSpeed *= 2f;
        player.GetRigidbody.MovePosition(player.GetRigidbody.position + moveVector * moveSpeed * Time.deltaTime);
    }

    public void Rotate()
    {
        var rotation = Quaternion.LookRotation(moveVector);
        player.transform.rotation = Quaternion.Slerp(player.GetRigidbody.rotation, rotation, rotateSpeed * Time.deltaTime);
    }

    public void OnWalk(InputAction.CallbackContext context)
    {
        var value = context.ReadValue<Vector2>();
        moveVector = new Vector3(value.x, 0, value.y);
        playerState.SetState(dicPlayerState[Player.PlayerState.Walk]);
    }

    public void OnRun(InputAction.CallbackContext context)
    {
        print("OnRun");
        if (context.performed && playerState.CurrentState == dicPlayerState[Player.PlayerState.Walk])
        {
            playerState.SetState(dicPlayerState[Player.PlayerState.Run]);
        }
        else if (context.canceled)
        {
            playerState.SetState(dicPlayerState[Player.PlayerState.Run]);
        }
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            playerState.SetState(dicPlayerState[Player.PlayerState.Attack]);
        }
    }

    public void OnDefend(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            playerState.SetState(dicPlayerState[Player.PlayerState.Defend]);
        }
    }

    public void OnDodge(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            playerState.SetState(dicPlayerState[Player.PlayerState.Dodge]);
        }
    }

    public void OnFocus(InputAction.CallbackContext context)
    {

    }
}

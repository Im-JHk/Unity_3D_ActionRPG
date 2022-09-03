using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour, PlayerInput.IPlayerActions
{
    private Player player = null;

    void Start()
    {
        player = GetComponent<Player>();
    }

    void Update()
    {

    }

    public void OnWalk(InputAction.CallbackContext context)
    {
        var value = context.ReadValue<Vector2>();
        player.MoveVector = new Vector3(value.x, 0, value.y);
        if (!player.CanChangeState) return;
        if(player.MoveVector != Vector3.zero && !player.IsRun)
        {
            player.GetPlayerState.SetState(player.GetDicPlayerState[Unit.BaseState.Walk]);
        }
        else if (context.canceled)
        {
            player.Move();
            player.GetPlayerState.SetState(player.GetDicPlayerState[Unit.BaseState.Idle]);
        }
    }

    public void OnRun(InputAction.CallbackContext context)
    {
        if (player.CanChangeState && context.performed && player.GetPlayerState.CurrentState == player.GetDicPlayerState[Unit.BaseState.Walk])
        {
            player.IsRun = true;
            player.GetPlayerState.SetState(player.GetDicPlayerState[Unit.BaseState.Run]);
        }
        else if (context.canceled)
        {
            player.IsRun = false;
            player.Move();
            if(player.IsMove) player.GetPlayerState.SetState(player.GetDicPlayerState[Unit.BaseState.Walk]);
            else player.GetPlayerState.SetState(player.GetDicPlayerState[Unit.BaseState.Idle]);
        }
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (player.CanChangeState && context.started)
        {
            player.GetPlayerState.SetState(player.GetDicPlayerState[Unit.BaseState.Attack]);
        }
    }

    public void OnDefend(InputAction.CallbackContext context)
    {
        if (player.CanChangeState && context.started)
        {
            player.GetPlayerState.SetState(player.GetDicPlayerState[Unit.BaseState.Defend]);
        }
    }

    public void OnDodge(InputAction.CallbackContext context)
    {
        if (player.CanChangeState && context.started)
        {
            player.GetPlayerState.SetState(player.GetDicPlayerState[Unit.BaseState.Dodge]);
        }
    }

    public void OnFocus(InputAction.CallbackContext context)
    {
        if (player.CanChangeState && context.started)
        {

        }
    }
}

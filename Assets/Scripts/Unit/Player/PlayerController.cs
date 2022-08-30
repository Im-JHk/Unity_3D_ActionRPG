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
        if(player.MoveVector != Vector3.zero && !player.IsRun)
        {
            player.GetPlayerState.SetState(player.GetDicPlayerState[Player.PlayerState.Walk]);
        }
        else if (context.canceled)
        {
            player.GetPlayerState.SetState(player.GetDicPlayerState[Player.PlayerState.Idle]);
        }
    }

    public void OnRun(InputAction.CallbackContext context)
    {
        if (context.performed && player.GetPlayerState.CurrentState == player.GetDicPlayerState[Player.PlayerState.Walk])
        {
            player.IsRun = true;
            player.MoveSpeed *= 2f;
            player.GetPlayerState.SetState(player.GetDicPlayerState[Player.PlayerState.Run]);
        }
        else if (context.canceled)
        {
            player.IsRun = false;
            player.MoveSpeed *= 0.5f;
        }
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            player.GetPlayerState.SetState(player.GetDicPlayerState[Player.PlayerState.Attack]);
        }
    }

    public void OnDefend(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            player.GetPlayerState.SetState(player.GetDicPlayerState[Player.PlayerState.Defend]);
        }
    }

    public void OnDodge(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            player.GetPlayerState.SetState(player.GetDicPlayerState[Player.PlayerState.Dodge]);
        }
    }

    public void OnFocus(InputAction.CallbackContext context)
    {

    }
}

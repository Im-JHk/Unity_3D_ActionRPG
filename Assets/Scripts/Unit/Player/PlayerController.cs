using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour, PlayerInput.IPlayerActions
{
    private Player player = null;
    private PlayerStat playerStat = null;

    private void Awake()
    {
        player = GetComponent<Player>();
        playerStat = GetComponent<PlayerStat>();
    }

    public void OnWalk(InputAction.CallbackContext context)
    {
        var value = context.ReadValue<Vector2>();
        player.MoveVector = new Vector3(value.x, 0, value.y);

        if (!player.CanChangeState) return;
        if(player.MoveVector != Vector3.zero && !player.IsRun)
        {
            player.StateMachine.SetState(player.DicState[NS_Unit.BaseState.Walk]);
        }
        else if (context.canceled)
        {
            player.SetMoveParameter();
            player.StateMachine.SetState(player.DicState[NS_Unit.BaseState.Idle]);
        }
    }

    public void OnRun(InputAction.CallbackContext context)
    {
        if (player.CanChangeState && context.performed && player.StateMachine.CurrentState == player.DicState[NS_Unit.BaseState.Walk])
        {
            player.StateMachine.SetState(player.DicState[NS_Unit.BaseState.Run]);
        }
        else if (context.canceled)
        {
            if(player.IsMove) player.StateMachine.SetState(player.DicState[NS_Unit.BaseState.Walk]);
            else player.StateMachine.SetState(player.DicState[NS_Unit.BaseState.Idle]);
        }
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (player.CanChangeState) player.StateMachine.SetState(player.DicState[NS_Unit.BaseState.Attack]);
            else if (player.CanComboAttack) player.StateMachine.OneMoreEnter(player.DicState[NS_Unit.BaseState.Attack]);
        }
    }

    public void OnDefend(InputAction.CallbackContext context)
    {
        if (player.CanChangeState && context.started)
        {
            player.StateMachine.SetState(player.DicState[NS_Unit.BaseState.Defend]);
        }
        if (context.canceled)
        {
            if (player.IsMove) player.StateMachine.SetState(player.DicState[NS_Unit.BaseState.Walk]);
            else player.StateMachine.SetState(player.DicState[NS_Unit.BaseState.Idle]);
        }
    }

    public void OnDodge(InputAction.CallbackContext context)
    {
        if (player.CanChangeState && context.started)
        {
            player.StateMachine.SetState(player.DicState[NS_Unit.BaseState.Dodge]);
        }
    }

    public void OnFocus(InputAction.CallbackContext context)
    {
        if (context.started)
        {

        }
    }
}

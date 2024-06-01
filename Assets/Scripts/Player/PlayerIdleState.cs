using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : IState
{
    private Player player;
    private PlayerStateMachine stateMachine;

    public PlayerIdleState(Player _player, PlayerStateMachine _stateMachine)
    {
        player = _player;
        stateMachine = _stateMachine;
    }
    
    public void Enter()
    {
        player.anim.SetBool("Idle", true);
    }

    public void Update()
    {
        throw new System.NotImplementedException();
    }

    public void Exit()
    {
        player.anim.SetBool("Idle", false);
    }

    public void LogicUpdate()
    {
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            Debug.Log("Player is in walk state");
            stateMachine.ChangeState(player.walkState);
            
        }
        else if (Input.GetKeyDown(KeyCode.W) && player.isGrounded())
        {
            
        }
    }

    public void PhysicsUpdate()
    {
        throw new System.NotImplementedException();
    }
}

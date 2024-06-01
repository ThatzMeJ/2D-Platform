using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalkState : IState
{
    private Player player;
    private PlayerStateMachine stateMachine;
    public PlayerWalkState(Player _player, PlayerStateMachine _stateMachine)
    {
        player = _player;
        stateMachine = _stateMachine;
    }
    public void Enter()
    {
        PlayerManager.instance.player.anim.SetBool("Walk",true);
    }

    public void Update()
    {
        throw new System.NotImplementedException();
    }

    public void Exit()
    {
        PlayerManager.instance.player.anim.SetBool("Walk", false);
    }

    public void LogicUpdate()
    {
        if (Input.GetAxisRaw("Horizontal") == 0)
        {
            stateMachine.ChangeState(player.idleState);
        }
    }

    public void PhysicsUpdate()
    {
        throw new System.NotImplementedException();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionState : State
{


    public TransitionState(Player player, StateMachine stateMachine) : base(player, stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }
    public override void HandleInput()
    {
        base.HandleInput();
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (GameManager.Instance.isGameOver == false) stateMachine.ChangeState(player.Create);
        else GameObject.Destroy(player.Platform);
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
    public override void Exit()
    {
        base.Exit();
    }
}

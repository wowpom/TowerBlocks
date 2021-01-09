using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyState : State
{
    private GameObject gameBlock;

    public FlyState(Player player, StateMachine stateMachine) : base(player, stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        gameBlock = player.GameBlock;
    }
    public override void HandleInput()
    {
        base.HandleInput();
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (player.isBlock)
        {
            stateMachine.ChangeState(player.Standing);
        }
        if (gameBlock.transform.position.y <= 355) 
        {
            GameManager.Instance.GameOver();
            stateMachine.ChangeState(player.Transition);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        gameBlock.transform.Translate(new Vector3(0, -0.5f, 0));
    }
    public override void Exit()
    {
        base.Exit();
    }
}

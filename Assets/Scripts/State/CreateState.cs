using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateState : State
{
    GameObject gameBlock;


    public CreateState(Player player, StateMachine stateMachine) : base(player, stateMachine)
    {
    }

    public override void Enter()
    {
        
        base.Enter();
        player.CreateBlock();
        gameBlock = player.GameBlock;
    }
    public override void HandleInput()
    {
        base.HandleInput();
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if(gameBlock.transform.position.y <= 375)
        {
            stateMachine.ChangeState(player.Swing);
        }
        if (Input.GetKeyDown(KeyCode.Space)) stateMachine.ChangeState(player.Fly);


        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                stateMachine.ChangeState(player.Fly);
            }
        }

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        gameBlock.transform.Translate(new Vector3(0, -0.7f, 0), Space.World);
    }


    public override void Exit()
    {
        base.Exit();
    }
}

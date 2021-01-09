using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingState : State
{
    private bool downSpace;
    private int direction;
    private GameObject gameBlock;
    public SwingState(Player player, StateMachine stateMachine) : base(player, stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        downSpace = false;
        direction = 1;
        gameBlock = player.GameBlock;
    }
    public override void HandleInput()
    {
        base.HandleInput();
        downSpace = Input.GetKey(KeyCode.Space);
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (downSpace)
        {
            stateMachine.ChangeState(player.Fly);
        }
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
        gameBlock.transform.Translate(new Vector3(GameManager.Instance.SpeedSwing * direction, 0, 0));
        if (gameBlock.transform.position.x <= 250) direction = 1;
        else if (gameBlock.transform.position.x >= 267) direction = -1;
    }
    public override void Exit()
    {
        base.Exit();
    }
}

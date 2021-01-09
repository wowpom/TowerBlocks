using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandingState : State
{
    private GameObject gameBlock;
    private GameObject lastBlock;

    private float maxXDistance;
    private float xDistance;
    public StandingState(Player player, StateMachine stateMachine) : base(player, stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        gameBlock = player.GameBlock;
        lastBlock = player.LastBlock;
        xDistance = gameBlock.transform.position.x - lastBlock.transform.position.x;
        maxXDistance = player.maxXDistance;
    }
    public override void HandleInput()
    {
        base.HandleInput();
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();
        //Проверка на растояния x куба и x платформы
        if ((xDistance < -maxXDistance || xDistance > maxXDistance)) {
            player.isBlock = false;
            GameObject.Destroy(gameBlock);
        }
        else
        {
            player.LastBlock = gameBlock;
            gameBlock.transform.parent = player.Platform.transform;
            if(xDistance == 0)
            {
                //Идеальная установка блока
                GameManager.Instance.GreatText();
                GameManager.Instance.Swinging = GameManager.Instance.Swinging - 2;
                if (GameManager.Instance.Swinging <= -1) GameManager.Instance.Swinging = 0;
                
            }
            else
            {
                //Не идеальная установка блока
                GameManager.Instance.Swinging++;
                if (GameManager.Instance.Swinging == GameManager.Instance.SwingingMax) GameManager.Instance.GameOver();
            }
            
            if (player.isLastBlock)
            {
                //Если это последний блок для уровня, платформы удаляется и создаётся новая
                GameObject.Destroy(player.Platform);
                GameManager.Instance.Swinging = 0;
                player.CreatePlatform();
                player.isLastBlock = false;
                player.LastBlock = player.Platform;
            }
            else
            {
                player.isPlatformDown = true;
                player.StartCoroutine(player.PlatformDown());
            }
            GameManager.Instance.ChangeScore();
        }
        player.isBlock = false;
        stateMachine.ChangeState(player.Transition);

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

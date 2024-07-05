using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class PlayerWallSlideState : PlayerState
{
	public PlayerWallSlideState(Player _player, PlayerStateMatchine _playerStateMatchine, string _animBoolName) : base(_player, _playerStateMatchine, _animBoolName)
	{
	}

	public override void Enter()
	{
		base.Enter();
	}

	public override void Exit()
	{
		base.Exit();
	}

	public override void Update()
	{
		base.Update();

		if (xInput != 0 && xInput != player.facingDir)
		{
			stateMachine.Change(player.playerIdle);
		}
	
		if (yInput < 0)
		{
			rb.velocity = new Vector2(0, rb.velocity.y);
		} 
		else
		{
			rb.velocity = new Vector2(0, rb.velocity.y * .7f);
		}


		if (player.IsGroundDetected())
		{
			stateMachine.Change(player.playerIdle);
		}
	}
}

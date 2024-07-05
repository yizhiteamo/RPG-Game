using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAirState : PlayerState
{
	public PlayerAirState(Player _player, PlayerStateMatchine _playerStateMatchine, string _animBoolName) : base(_player, _playerStateMatchine, _animBoolName)
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

		if (player.IsWallDetected())
		{
			player.stateMachine.Change(player.wallSlide);
		}

		if (player.IsGroundDetected())
		{
			player.stateMachine.Change(player.playerIdle);
		}

		if (xInput != 0)
		{
			player.SetVelocity(player.moveSpeed * .8f * xInput, rb.velocity.y);
		}
	}
}

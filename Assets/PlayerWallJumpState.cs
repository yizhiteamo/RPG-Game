using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallJumpState : PlayerState
{
	public PlayerWallJumpState(Player _player, PlayerStateMatchine _playerStateMatchine, string _animBoolName) : base(_player, _playerStateMatchine, _animBoolName)
	{
	}

	public override void Enter()
	{
		base.Enter();

		stateTimer = .4f;

		player.SetVelocity(5f * -player.facingDir, player.jumpForce);
	}

	public override void Exit()
	{
		base.Exit();
	}

	public override void Update()
	{
		base.Update();

		if (stateTimer < 0)
		{
			player.stateMachine.Change(player.airState);
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdle : PlayerGroundedState
{
	public PlayerIdle(Player _player, PlayerStateMatchine _playerStateMatchine, string _animBoolName) : base(_player, _playerStateMatchine, _animBoolName)
	{
	}

	public override void Enter()
	{
		base.Enter();

		player.ZeroVelocity();
	}

	public override void Exit()
	{
		base.Exit();
	}

	public override void Update()
	{

		base.Update();

		if (xInput != 0 && !player.IsWallDetected() && !player.isBusy)
		{
			player.stateMachine.Change(player.moveState);
		}

	}
}

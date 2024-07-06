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

		player.SetVelocity(0f, 0f);
	}

	public override void Exit()
	{
		base.Exit();
	}

	public override void Update()
	{

		base.Update();

		if (xInput != 0 && !player.IsWallDetected())
		{
			player.stateMachine.Change(player.moveState);
		}

	}
}

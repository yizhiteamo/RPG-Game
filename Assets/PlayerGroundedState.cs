using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundedState : PlayerState
{
	public PlayerGroundedState(Player _player, PlayerStateMatchine _playerStateMatchine, string _animBoolName) : base(_player, _playerStateMatchine, _animBoolName)
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

		if (!player.IsGroundDetected())
		{
			player.stateMachine.Change(player.airState);
		}

		if (Input.GetKeyDown(KeyCode.Space))
		{
			player.stateMachine.Change(player.playerJump);
		}
	}
}

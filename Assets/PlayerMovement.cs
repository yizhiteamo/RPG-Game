using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : PlayerGroundedState
{
	public PlayerMovement(Player _player, PlayerStateMatchine _playerStateMatchine, string _animBoolName) : base(_player, _playerStateMatchine, _animBoolName)
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

		player.SetVelocity(xInput * player.moveSpeed, rb.velocity.y);

		if (xInput == 0 || player.IsWallDetected())
		{
			player.stateMachine.Change(player.idelState);
		}
		
		if (Input.GetKeyDown(KeyCode.Mouse0))
		{
			player.SetVelocity(0, 0);
		}

	}
}

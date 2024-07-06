using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrimaryAttackState : PlayerState
{
	public PlayerPrimaryAttackState(Player _player, PlayerStateMatchine _playerStateMatchine, string _animBoolName) : base(_player, _playerStateMatchine, _animBoolName)
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

		if (triggerCalled)
		{
			player.stateMachine.Change(player.idelState);
		}
	}
}

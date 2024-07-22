using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrimaryAttackState : PlayerState
{

	private int comboConuter;
	private float lastTimeAttack;
	private float comboWindow = 2f;

	public PlayerPrimaryAttackState(Player _player, PlayerStateMatchine _playerStateMatchine, string _animBoolName) : base(_player, _playerStateMatchine, _animBoolName)
	{
	}

	public override void Enter()
	{
		base.Enter();

		if (comboConuter > 2 || Time.time >= (lastTimeAttack + comboWindow))
		{
			comboConuter = 0;
		}

		stateTimer = .1f;

		player.SetVelocity(player.attackMovement[comboConuter].x * player.facingDir, player.attackMovement[comboConuter].y);

		player.anim.SetInteger("ComboCounter", comboConuter);
	}

	public override void Exit()
	{
		comboConuter++;
		lastTimeAttack = Time.time;
		player.StartCoroutine("BusyFor", .15f);
		base.Exit();
	}

	public override void Update()
	{
		base.Update();

		if (triggerCalled)
		{
			player.stateMachine.Change(player.idelState);
		}

		if (stateTimer < 0)
		{
			player.ZeroVelocity();
		}
	}
}

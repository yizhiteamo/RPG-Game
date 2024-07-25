using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonIdelState : EnemyState
{

	private Enemy_Skeleton enemy;

	public SkeletonIdelState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName, Enemy_Skeleton enemy) : base(_enemyBase, _stateMachine, _animBoolName)
	{
		this.enemy = enemy;
	}

	public override void Enter()
	{
		base.Enter();

		stateTimer = enemy.idleTime;
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
			stateMachine.Change(enemy.moveState);
		}
	}
}

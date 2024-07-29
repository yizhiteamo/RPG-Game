using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonIdelState : SkeletonGroundedState
{
	public SkeletonIdelState(Enemy baseEnemy, EnemyStateMachine _stateMachine, string _animBoolName, Enemy_Skeleton _enemy) : base(baseEnemy, _stateMachine, _animBoolName, _enemy)
	{

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

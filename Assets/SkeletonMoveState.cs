using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonMoveState : SkeletonGroundedState
{
	public SkeletonMoveState(Enemy baseEnemy, EnemyStateMachine _stateMachine, string _animBoolName, Enemy_Skeleton _enemy) : base(baseEnemy, _stateMachine, _animBoolName, _enemy)
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

		enemy.SetVelocity(enemy.moveSpeed * enemy.facingDir, rb.velocity.y);

		if (!enemy.IsGroundDetected() || enemy.IsWallDetected())
		{
			enemy.Flip();
			stateMachine.Change(enemy.idelState);
		}
	}
}

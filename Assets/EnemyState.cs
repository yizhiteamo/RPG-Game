using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState
{
	protected EnemyStateMachine stateMachine;
	protected Enemy enemyBase;

	private string animBoolName;

	protected bool triggerCalled;
	protected float stateTimer;

	public EnemyState(Enemy _enemy, EnemyStateMachine _stateMachine, string _animBoolName)
	{
		this.enemyBase = _enemy;
		this.stateMachine = _stateMachine;
		this.animBoolName = _animBoolName;
	}

	public virtual void Enter()
	{
		triggerCalled = false;
		enemyBase.anim.SetBool(animBoolName, true);
	}

	public virtual void Exit()
	{
		enemyBase.anim.SetBool(animBoolName, false);
	}

	public virtual void Update()
	{
		stateTimer -= Time.deltaTime;
	}


}

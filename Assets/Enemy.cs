using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
	[SerializeField] protected LayerMask whatIsPlayer;

	[Header("Move Info")]
	public float moveSpeed;
	public float idleTime;
	[Header("Attack Info")]
	public float attackDistance;

	public EnemyStateMachine stateMachine { get; private set; }

	protected override void Awake()
	{
		base.Awake();
		stateMachine = new EnemyStateMachine();
	}

	protected override void Update()
	{
		base.Update();
		stateMachine.currentState.Update();

		Debug.Log(IsPlayerDetected().collider.gameObject.name);
	}

	public virtual RaycastHit2D IsPlayerDetected() => Physics2D.Raycast(wallCheckCollision.position, Vector2.right * facingDir, 50f, whatIsPlayer);

	protected override void OnDrawGizmos()
	{
		base.OnDrawGizmos();

		Gizmos.color = Color.yellow;
		Gizmos.DrawLine(transform.position, new Vector3(transform.position.x + attackDistance * facingDir, transform.position.y));
	}
}

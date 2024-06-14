using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class Enemy_Skeleton : Entity
{

	[Header("Move Info")]
	[SerializeField] private float moveSpeed = 5f;
	[SerializeField] private float aggressiveSpeed = 2f;

	[Header("Player Detection")]
	[SerializeField] private float playerCheckDistance;
	[SerializeField] private LayerMask whatIsPlayer;

	private RaycastHit2D isPlayerDetected;

	private bool isAttacking;

	protected override void Start()
	{
		base.Start();
	}

	protected override void Update()
	{
		base.Update();

		if (isPlayerDetected)
		{
			if (playerCheckDistance > 1)
			{
				isAttacking = false;
				rb.velocity = new Vector2(faceDir * moveSpeed * aggressiveSpeed, rb.velocity.y);
				Debug.Log("see the player");
			}
			else
			{
				isAttacking = true;
				Debug.Log("Attacking!");
			}
		} 
		else
		{
			Movement();
		}


		if (!isGrounded || isWallDetected)
		{
			Flip();
		}

		
	}

	private void Movement()
	{
		if (!isAttacking)
		{
			rb.velocity = new Vector2(faceDir * moveSpeed, rb.velocity.y);
		}
	}

	protected override void CollisionChecks()
	{
		base.CollisionChecks();

		isPlayerDetected = Physics2D.Raycast(transform.position, Vector2.right, playerCheckDistance * faceDir, whatIsPlayer);

	}

	protected override void OnDrawGizmos()
	{
		base.OnDrawGizmos();

		Gizmos.color = Color.blue;

		Gizmos.DrawLine(transform.position, new Vector3(transform.position.x + playerCheckDistance * faceDir, transform.position.y));
	}
}

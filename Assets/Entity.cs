using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{


	#region Components
	public Animator anim { get; private set; }
	public Rigidbody2D rb { get; private set; }
	#endregion

	[Header("Collision Info")]
	[SerializeField] protected Transform wallCheckCollision;
	[SerializeField] protected float wallCheckDistance;
	[SerializeField] protected Transform groundCheckCollision;
	[SerializeField] protected float groundCheckDistance;
	[SerializeField] protected LayerMask whatIsGround;

	public int facingDir { get; private set; } = 1;
	protected bool facingRight = true;

	protected virtual void Awake()
	{
		anim = GetComponentInChildren<Animator>();

		rb = GetComponent<Rigidbody2D>();
	}

	protected virtual void Start()
	{

	}

	protected virtual void Update()
	{

	}

	#region Collision

	public virtual bool IsGroundDetected() => Physics2D.Raycast(groundCheckCollision.position, Vector2.down, groundCheckDistance, whatIsGround);

	public virtual bool IsWallDetected() => Physics2D.Raycast(wallCheckCollision.position, Vector2.right * facingDir, wallCheckDistance, whatIsGround);

	protected virtual void OnDrawGizmos()
	{
		Gizmos.DrawLine(groundCheckCollision.position, new Vector3(groundCheckCollision.position.x, groundCheckCollision.position.y - groundCheckDistance));
		Gizmos.DrawLine(wallCheckCollision.position, new Vector3(wallCheckCollision.position.x + wallCheckDistance, wallCheckCollision.position.y));
	}

	#endregion

	#region Flip
	public virtual void Flip()
	{
		facingDir *= -1;
		facingRight = !facingRight;
		transform.Rotate(0, 180, 0);
	}

	public virtual void FlipController(float _x)
	{
		if (facingRight && _x < 0)
		{
			Flip();
		}
		else if (!facingRight && _x > 0)
		{
			Flip();
		}
	}
	#endregion

	#region Velocity
	public virtual void ZeroVelocity() => rb.velocity = new Vector2(0, 0);

	public virtual void SetVelocity(float _xVelocity, float _yVelocity)
	{
		rb.velocity = new Vector2(_xVelocity, _yVelocity);

		FlipController(_xVelocity);
	}
	#endregion
}

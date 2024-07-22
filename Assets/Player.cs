using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

	[Header("Attack Detail")]
	public Vector2[] attackMovement;

	public bool isBusy { get; private set; }
	[Header("Move Info")]
	public float moveSpeed = 8f;
	public float jumpForce = 12f;

	[Header("Dash Info")]
	private float dashUsageTimer;
	private float dashColdDown = 1f;
	public float dashSpeed = 25f;
	public float dashDuration = .2f;
	public float dashDir {  get; private set; }

	[Header("Collision Info")]
	public Transform wallCheckCollision;
	public float wallCheckDistance;
	public Transform groundCheckCollision;
	public float groundCheckDistance;

	public LayerMask whatIsGround;


	#region Components
	public Animator anim {  get; private set; }
	public Rigidbody2D rb { get; private set; }
	#endregion

	#region States
	public PlayerStateMatchine stateMachine {  get; private set; }
	public PlayerIdle idelState { get; private set; }
	public PlayerMovement moveState { get; private set; }
	public PlayerJumpState jumpState { get; private set; }
	public PlayerAirState airState { get; private set; }
	public PlayerDashState dashState { get; private set; }
	public PlayerWallSlideState wallSlide { get; private set; }
	public PlayerWallJumpState wallJump { get; private set; }
	public PlayerPrimaryAttackState primaryAttack { get; private set; }
	#endregion

	public int facingDir { get; private set; } = 1;
	public bool facingRight = true;


	private void Awake()
	{
		stateMachine = new PlayerStateMatchine();

		idelState = new PlayerIdle(this, stateMachine, "Idle");

		moveState = new PlayerMovement(this, stateMachine, "Move");

		jumpState = new PlayerJumpState(this, stateMachine, "Jump");

		airState  = new PlayerAirState(this, stateMachine, "Jump");

		dashState = new PlayerDashState(this, stateMachine, "Dash");

		wallSlide = new PlayerWallSlideState(this, stateMachine, "WallSlide");

		wallJump  = new PlayerWallJumpState(this, stateMachine, "Jump");

		primaryAttack = new PlayerPrimaryAttackState(this, stateMachine, "Attack");
	}

	private void Start()
	{

		anim = GetComponentInChildren<Animator>();

		rb = GetComponent<Rigidbody2D>();

		stateMachine.Initialize(idelState);

	}

	private void Update()
	{
		dashUsageTimer -= Time.deltaTime;
		stateMachine.currentState.Update();
		CheckForDashInput();
	}

	public IEnumerator BusyFor(float _second)
	{
		isBusy = true;
		yield return new WaitForSeconds(_second);
		isBusy = false;

	}

	public void AnimationTrigger() => stateMachine.currentState.AnimationFinishTrigger();

	public void CheckForDashInput()
	{

		if (IsWallDetected())
		{
			return;
		}

		if (Input.GetKeyDown(KeyCode.LeftShift) && dashUsageTimer <= 0) {

			dashDir = Input.GetAxisRaw("Horizontal");

			if (dashDir == 0)
			{
				dashDir = facingDir;
			}

			dashUsageTimer = dashColdDown;
			
			stateMachine.Change(dashState);
		}

	}

	#region Velocity
	public void ZeroVelocity() => rb.velocity = new Vector2 (0, 0);

	public void SetVelocity(float _xVelocity, float _yVelocity)
	{
		rb.velocity = new Vector2(_xVelocity, _yVelocity);

		FlipController(_xVelocity);
	}
	#endregion

	#region Collision

	public bool IsGroundDetected() => Physics2D.Raycast(groundCheckCollision.position, Vector2.down, groundCheckDistance, whatIsGround);

	public bool IsWallDetected() => Physics2D.Raycast(wallCheckCollision.position, Vector2.right * facingDir, wallCheckDistance, whatIsGround);

	public void OnDrawGizmos()
	{
		Gizmos.DrawLine(groundCheckCollision.position, new Vector3(groundCheckCollision.position.x, groundCheckCollision.position.y - groundCheckDistance));
		Gizmos.DrawLine(wallCheckCollision.position, new Vector3(wallCheckCollision.position.x + wallCheckDistance, wallCheckCollision.position.y));
	}

	#endregion

	#region Flip
	public void Flip()
	{
		facingDir *= -1;
		facingRight = !facingRight;
		transform.Rotate(0, 180, 0);
	}

	public void FlipController(float _x)
	{
		if (facingRight && _x < 0)
		{
			Flip();
		} else if (!facingRight && _x > 0)
		{
			Flip();
		}
	}
	#endregion
}

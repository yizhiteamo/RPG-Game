using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
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

	protected override void Awake()
	{

		base.Awake();

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

	protected override void Start()
	{
		base.Start();
		stateMachine.Initialize(idelState);
	}

	protected override void Update()
	{
		base.Update();
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
}

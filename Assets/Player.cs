using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    private float inputX = 0;

	[Header("Move Info")]
    [SerializeField] private float jumpForce = 5;
	[SerializeField] private float moveSpeed = 5;


	[Header("Dash Info")]
	[SerializeField] private float dashSpeed;
	[SerializeField] private float dashDuration;
	[SerializeField] private float dashTime;

	[Header("Attack Info")]
	[SerializeField] private bool isAttacking;
	[SerializeField] private int combCounter;
	[SerializeField] private float combTime;
	private float combWindowTime;

	protected override void Start()
	{
		base.Start();
	}

	// Update is called once per frame
	protected override void Update()
	{

		base.Update();

		combWindowTime -= Time.deltaTime;

		InputCheck();
		Movement();
		FlipControllers();

		Dashing();

		AnimatorControllers();
	}

	private void Dashing()
	{
		dashTime -= Time.deltaTime;
		if (Input.GetKeyDown(KeyCode.LeftShift))
		{
			dashTime = dashDuration;
		}
	}



	private void InputCheck()
	{
		inputX = Input.GetAxis("Horizontal");
		if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
		{
			Jump();
		}

		if (Input.GetKeyDown(KeyCode.Mouse0))
		{
			StartAttackEvent();
		}

	}

	private void StartAttackEvent()
	{

		if (!isGrounded)
		{
			return;
		}

		if (combWindowTime < 0)
		{
			combCounter = 0;
		}
		isAttacking = true;
		combWindowTime = combTime;
	}

	public void AttackOver()
	{
		isAttacking = false;
		combCounter++;
		combCounter %= 3;
	}

	private void Movement()
	{
		if (isAttacking)
		{
			rb.velocity = new Vector2(0, 0);
		}
		else if (dashTime > 0)
		{
			rb.velocity = new Vector2(faceDir * dashSpeed, 0);
		}
		else
		{
			rb.velocity = new Vector2(inputX * moveSpeed, rb.velocity.y);
		}

	}

	private void Jump()
	{
		rb.velocity = new Vector2(rb.velocity.x, jumpForce);
	}

	private void AnimatorControllers()
	{
		bool isMoving = rb.velocity.x != 0;
		anim.SetBool("is_Moving", isMoving);
		anim.SetBool("is_Grounded", isGrounded);
		anim.SetFloat("y_Velocity", rb.velocity.y);
		anim.SetBool("is_Dasing", dashTime > 0);
		anim.SetBool("is_Attacking", isAttacking);
		anim.SetInteger("comb_Counter", combCounter);
	}

	private void FlipControllers()
	{
		if (rb.velocity.x > 0 && !faceRight)
		{
			Flip();
		}
		else if (rb.velocity.x < 0 && faceRight)
		{
			Flip();
		}
	}

	protected override void CollisionChecks()
	{
		base.CollisionChecks();
	}
}

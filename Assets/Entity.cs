using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{

    protected Animator anim;
    protected Rigidbody2D rb;

	[Header("Collision Info")]
	[SerializeField] protected Transform groundCheck;
	[SerializeField] protected float groundCheckDistance;
	[Space]
	[SerializeField] protected float wallCheckDistance;
	[SerializeField] protected Transform wallCheck;
	[SerializeField] protected LayerMask whatIsGround;

	protected bool isGrounded;
	protected bool isWallDetected;

	protected int faceDir = 1;
	protected bool faceRight = true;


	// Start is called before the first frame update
	protected virtual void Start()
    {
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();

		if (wallCheck == null)
		{
			wallCheck = transform;
		}
    }

    // Update is called once per frame
    protected virtual void Update()
    {
		CollisionChecks();

	}

	protected virtual void CollisionChecks()
	{
		isGrounded = Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, whatIsGround);

		isWallDetected = Physics2D.Raycast(wallCheck.position, Vector2.right, wallCheckDistance * faceDir, whatIsGround);
	}

	protected virtual void OnDrawGizmos()
	{
		Gizmos.DrawLine(groundCheck.position, new Vector3(groundCheck.position.x, groundCheck.position.y - groundCheckDistance));

		Gizmos.DrawLine(wallCheck.position, new Vector3(wallCheck.position.x + wallCheckDistance * faceDir, wallCheck.position.y));
	}


	protected virtual void Flip()
	{
		faceDir *= -1;
		faceRight = !faceRight;

		transform.Rotate(0, 180, 0);
	}


}

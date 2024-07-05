using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState
{
	protected PlayerStateMatchine stateMachine;
	protected Player player;
	protected float xInput;
	protected float yInput;
	protected Rigidbody2D rb;
	protected float stateTimer;

	private string animBoolName;

	public PlayerState(Player _player, PlayerStateMatchine _playerStateMatchine, string _animBoolName)
	{
		this.player = _player;
		this.animBoolName = _animBoolName;
		this.stateMachine = _playerStateMatchine;
	}

	public virtual void Enter() 
	{
		player.anim.SetBool(animBoolName, true);

		rb = player.rb;
	}
	public virtual void Update() 
	{
		xInput = Input.GetAxisRaw("Horizontal");
		yInput = Input.GetAxisRaw("Vertical");
		player.anim.SetFloat("yVelocity", rb.velocity.y);

		stateTimer -= Time.deltaTime;

	}

	public virtual void Exit() 
	{
		player.anim.SetBool(animBoolName, false);
	}
}

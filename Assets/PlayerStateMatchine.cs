using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMatchine
{
	public PlayerState currentState {  get; private set; }

	public void Initialize(PlayerState _startState)
	{
		currentState = _startState;
		currentState.Enter();
	}

	public void Change(PlayerState _newState)
	{
		currentState.Exit();
		currentState = _newState;
		currentState.Enter();
	}


}

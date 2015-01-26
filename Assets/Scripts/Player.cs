// File:	Player.cs
// Project: Pung3D
// Description: Player controlls for the paddle
//
// Author: Ryan Sands
// Date: 12/08/2014
// Copyright (c) 2014 Ryan Sands. All rights reserved.


using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{

	private CharacterController controller;
	private int speed;
	private Vector3 move;

	void Awake()
	{
		speed = MainMenu.paddleSpeed;
		Debug.Log ("" + speed);
	}


	void Start () 
	{
		// Assign the attached Game Object's Character Controller 
		controller = GetComponent<CharacterController> ();
	}

	// Update is called once per frame
	void Update () 
	{
		//Player input
		move = new Vector3 (0, Input.GetAxis ("Vertical"), 0);

		controller.Move (move * speed);

		if(Input.GetKeyDown("escape"))
		{
			Application.LoadLevel(1);
		}

	
	}
}

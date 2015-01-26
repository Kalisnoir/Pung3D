// File:	Enemy.cs
// Project:
// Description: Control the enemy padle
//
// Author: Ryan Sands
// Date:
// Copyright (c) 2014 Ryan Sands. All rights reserved.


using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{


	private GameObject ballObject;
	private int difficulty = 0;
	private float speed = 3;

	void Awake()
	{
		difficulty = MainMenu.difficulty;
	}


	// Use this for initialization
	void Start () 
	{
		// Find Game Object named Ball and assign to variable
		ballObject = GameObject.Find ("Ball");	

		// Change speed of paddle based on game difficulty
		switch(difficulty)
		{
		case 0:
			speed = 3;
			break;
		case 1:
			speed = 7;
			break;
		case 2:
			speed = 10;
			break;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		// If the ball position is above the paddle, move up at the speed defined
		if (ballObject.transform.position.y > this.transform.position.y + 0.01f && this.transform.position.y < 4.9f) 
		{
			transform.Translate(new Vector3(0, speed, 0) * Time.deltaTime);
				
		}
		// If the ball position is below the paddle, move down at the speed defined
		else if (ballObject.transform.position.y < this.transform.position.y - 0.01f && this.transform.position.y > -4.95f) 
		{
			transform.Translate(new Vector3(0, -speed, 0) * Time.deltaTime);
		}
	
	}

}

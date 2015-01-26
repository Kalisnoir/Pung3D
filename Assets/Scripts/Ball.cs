// File:	Ball.cs
// Project: Pung3D
// Description:	Control ball physics, scoring and gui elements
//
// Author: Ryan Sands
// Date: 12/08/2014


using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour 
{
	public Vector3 velocity;
	public Vector3 localVel;
	public float curSpeed = 0;
	
	//Difficulty, difficulty speed multiplier, max speeds
	public int difficulty = 0;
	public float angle = 1.2f;

	private const float easy = 1.1f;
	private const float maxSpeedEasy = 6;

	private const float medium = 1.2f;
	private const float maxSpeedMedium = 13;

	private const float hard = 1.5f;
	private const float maxSpeedHard = 16;

	//Score variables
	private int playerScore = 0;
	private int enemyScore = 0;
	

	private GameObject playerGUI;
	private GameObject enemyGUI;



	void Awake()
	{
		// Assign variables to GameObjects for score GUI update
		playerGUI = GameObject.Find ("Player Score");
		enemyGUI = GameObject.Find ("Enemy Score");

		// Get difficulty set in main menu
		difficulty = MainMenu.difficulty;

	}

	// Use this for initialization
	void Start () 
	{
		// Reset position and velocity
		transform.position = new Vector3 (0, 0, 0);
		rigidbody.velocity = new Vector3 (0, 0, 0);

		// Start movement of ball based on difficulty
		if(difficulty == 0)
		{
		rigidbody.AddForce (new Vector3 (-200, 0, 0));
		}
		else if(difficulty == 1)
		{
			rigidbody.AddForce (new Vector3 (-300, 0, 0));
		}
		else if(difficulty == 2)
		{
			rigidbody.AddForce (new Vector3 (-400, 0, 0));
		}
	}
	
	// Update is called once per frame
	void Update () 
	{	
		// Debug informantion
		velocity = rigidbody.velocity;
		curSpeed = Vector3.Magnitude (rigidbody.velocity);

		// Score + boundaries
		// If ball position is past the players side
		if (transform.position.x < -8) 
		{
			enemyScore++;
			enemyGUI.guiText.text = ("" + enemyScore);
			Start ();
		}
		// If the ball position is past the enemy side
		else if(transform.position.x > 8)
		{
			playerScore++;
			playerGUI.guiText.text = ("" + playerScore);
			Start ();
		}

	}

	// Debug information for speed of ball
	void OnCollisionEnter(Collision col)
	{
		Debug.Log ("Speed = " + curSpeed);
	}

	void OnCollisionExit(Collision col)
	{
		// Detect where on the paddle the ball has colided
		float hitPosition = (rigidbody.position.y - col.gameObject.transform.position.y);

		// Speed control
		// If the ball collides with the player, increase velocity on the x and y axis in the direction towards the enemy
		if (col.gameObject.name == "Player") 
		{
			if(difficulty == 0 && curSpeed < maxSpeedEasy)
			{
				rigidbody.velocity = new Vector3(rigidbody.velocity.x * easy, rigidbody.velocity.y * easy, rigidbody.velocity.z);
			}
			else if(difficulty == 1 && curSpeed < maxSpeedMedium)
			{
				rigidbody.velocity = new Vector3(rigidbody.velocity.x * medium, rigidbody.velocity.y * medium, rigidbody.velocity.z);
			}
			else if(difficulty == 2 && curSpeed < maxSpeedHard)
			{
				rigidbody.velocity = new Vector3(rigidbody.velocity.x * hard, rigidbody.velocity.y * hard, rigidbody.velocity.z);
			}

			// Control ball direction.
			if(col.gameObject.name == "Player" && hitPosition > 0.2f)
			{
				rigidbody.AddForce (new Vector3(0, 200, 0));
			}
			else if(col.gameObject.name == "Player" && hitPosition < -0.2f)
			{
				rigidbody.AddForce (new Vector3(0, -200, 0));
			}
		}

		// If the ball collides with the enemy, increase velocity on the x and y axis in the direction towards the player
		else if (col.gameObject.name == "Enemy") 
		{
			if(difficulty == 0 && curSpeed < maxSpeedEasy)
			{
				rigidbody.velocity = new Vector3(-rigidbody.velocity.x * -easy, rigidbody.velocity.y * - easy, rigidbody.velocity.z);
			}
			else if(difficulty == 1 && curSpeed < maxSpeedMedium)
			{
				rigidbody.velocity = new Vector3(-rigidbody.velocity.x * -medium, rigidbody.velocity.y * - medium, rigidbody.velocity.z);
			}
			else if(difficulty == 2 && curSpeed < maxSpeedHard)
			{
				rigidbody.velocity = new Vector3(-rigidbody.velocity.x * -hard, rigidbody.velocity.y * - hard, rigidbody.velocity.z);
			}
		}

		// If collide with bottom wall, increase only the x axis speed, however if the velocity if below 1, add force to stop the ball getting stuck
		if(col.gameObject.name == "WallBottom")
		{
			if(rigidbody.velocity.x > 0f)
			{
				rigidbody.velocity = new Vector3(rigidbody.velocity.x * 1.5f, rigidbody.velocity.y, rigidbody.velocity.z);
				if(rigidbody.velocity.x > 0f && rigidbody.velocity.x < 1f)
				{
					rigidbody.AddForce (100, 0, 0);
				}
			}
			else if(rigidbody.velocity.x < 0f)
			{
				rigidbody.velocity = new Vector3(-rigidbody.velocity.x * -1.5f, rigidbody.velocity.y, rigidbody.velocity.z);
				if(rigidbody.velocity.x < 0f && rigidbody.velocity.x > -1f)
				{
					rigidbody.AddForce (-100, 0, 0);
				}
			}

		}

		// If collide with top wall, increase only the x axis speed, however if the velocity if below 1, add force to stop ball getting stuck
		if(col.gameObject.name == "WallTop")
		{
			if(rigidbody.velocity.x > 0f)
			{
				rigidbody.velocity = new Vector3(rigidbody.velocity.x * 1.5f, rigidbody.velocity.y, rigidbody.velocity.z);
				if(rigidbody.velocity.x > 0f && rigidbody.velocity.x < 1f)
				{
					rigidbody.AddForce (100, 0, 0);
				}
			}
			else if(rigidbody.velocity.x < 0f)
			{
				rigidbody.velocity = new Vector3(-rigidbody.velocity.x * -1.5f, rigidbody.velocity.y, rigidbody.velocity.z);
				if(rigidbody.velocity.x < 0f && rigidbody.velocity.x > -1f)
				{
					rigidbody.AddForce (-100, 0, 0);
				}
			}
		}
	}
}

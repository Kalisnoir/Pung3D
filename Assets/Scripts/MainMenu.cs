// File:	MainMenu.cs
// Project: Pung3D
// Description: GUI Button creation and difficulty control for the title/main menu screen
//
// Author: Ryan Sands
// Date: 21/08/2014
// Copyright (c) 2014 Ryan Sands. All rights reserved.


using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour 
{
	public static int difficulty = 0;
	public static int paddleSpeed = 1;
	private string difficultyString;


	void Start () 
	{
	
	}
	

	void Update () 
	{
		switch(difficulty)
		{
		case 0: 
			difficultyString = "Easy";
			break;
		case 1: 
			difficultyString = "Medium";
			break;
		case 2:
			difficultyString = "Hard";
			break;
		}
	
	}

	void OnGUI ()
	{
		if (GUI.Button(new Rect(15, Screen.height - 65, 100, 35), "Play!"))
		{
			Application.LoadLevel(2);
		}

		if(GUI.Button(new Rect(130, Screen.height - 65, 100, 35), new GUIContent("Difficulty", difficultyString)))
		{
			if(difficulty < 2)
			{
				difficulty++;
			}
			else
				difficulty = 0;
		}




		if (GUI.Button(new Rect(245, Screen.height - 65, 100, 35), "Instructions"))
		{
			Application.LoadLevel(3);
		}

		if(GUI.Button (new Rect(360, Screen.height - 65, 100, 35), new GUIContent("Paddle Speed", paddleSpeed.ToString())))
		{
			if(paddleSpeed < 10)
			{
				paddleSpeed++;
			}
			else
				paddleSpeed = 1;
		}

		if(GUI.tooltip == "Easy" || GUI.tooltip == "Medium" || GUI.tooltip == "Hard")
		{
		GUI.Label(new Rect(165, Screen.height - 25, 100, 35), GUI.tooltip);
		}
		else
		GUI.Label (new Rect (405, Screen.height - 25, 100, 35), GUI.tooltip);
	}
}

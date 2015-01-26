// File:	InstructionsScene.cs
// Project: Pung3D
// Description: Keyboard controls for instructions scene
//
// Author: Ryan Sands
// Date: 21/08/2014
// Copyright (c) 2014 Ryan Sands. All rights reserved.


using UnityEngine;
using System.Collections;

public class InstructionsScene : MonoBehaviour 
{


	void Start () 
	{
	
	}
	

	void Update () 
	{
		if(Input.GetKeyDown("escape"))
		{
			Application.LoadLevel(1);
		}
	
	}
}

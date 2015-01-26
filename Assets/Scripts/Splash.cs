// File:	Splash.cs
// Project: Pung3D
// Description: Splash screen control
//
// Author: Ryan Sands
// Date: 22/08/2014
// Copyright (c) 2014 Ryan Sands. All rights reserved.


using UnityEngine;
using System.Collections;

public class Splash : MonoBehaviour 
{

	private GameObject unityLogo;
	private GameObject unityText;
	private GameObject ryanLogo;
	private GameObject ryanText;
	private GameObject ryanText2;
	private GameObject pung;

	void Awake ()
	{
		unityLogo = GameObject.Find ("Unity Logo");
		unityText = GameObject.Find ("Unity Text");
		ryanLogo = GameObject.Find ("Ryan Logo");
		ryanText = GameObject.Find ("Ryan Text");
		ryanText2 = GameObject.Find ("Ryan Text 2");
	}

	void Start () 
	{
		Invoke ("Unity", 3);
		Invoke ("Ryan", 3);
		Invoke ("Ryan", 6);
		Invoke ("LoadMenu", 6);
	}

	void Unity ()
	{
		unityText.guiText.enabled = false;
		unityLogo.guiTexture.enabled = false;
	}

	void Ryan ()
	{
		ryanText.guiText.enabled = !ryanText.guiText.enabled;
		ryanText2.guiText.enabled = !ryanText2.guiText.enabled;
		ryanLogo.guiTexture.enabled = !ryanLogo.guiTexture.enabled;
	}

	void LoadMenu()
	{
		Application.LoadLevel (1);
	}
	

	void Update () 
	{

	
	}
}

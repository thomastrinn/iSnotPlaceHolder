﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OpenAlapScene() {
		SceneManager.LoadScene("Alap", LoadSceneMode.Single);
	}

	public void OpenHangulatkeltoScene() {
		SceneManager.LoadScene("Hangulatkelto", LoadSceneMode.Single);
	}

	public void OpenJatekScene() {
		SceneManager.LoadScene("Jatek", LoadSceneMode.Single);
	}

	public void OpenMainMenuScene() {
		SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
	}
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public GameObject game;
	public GameObject enemyGenerator;

	private Animator animator;


	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		//Überprüfung des aktuellen Status - playing
		bool gamePlaying = game.GetComponent<GameController>().gameState == GameState.Playing;
		if (gamePlaying && (Input.GetKeyDown("up") || Input.GetMouseButtonDown(0))){
			UpdateState("PlayerJump");
		}
		
	}

	public void UpdateState(string state = null){
		if (state != null){
			animator.Play(state);
		}
	}

	void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.tag == "Enemy"){
			//Debug.Log("I'm dying!!!!");
			UpdateState("PlayerDie");
			game.GetComponent<GameController>().gameState = GameState.Ended;
			enemyGenerator.SendMessage("CancelGenerator", true); // keine Feinde mehr
			//Koalition - Punkte
		}else if (other.gameObject.tag == "Point"){
			game.SendMessage("IncreasePoints");
		}
    }

	void GameReady(){
		game.GetComponent<GameController>().gameState = GameState.Ready;
	}
}

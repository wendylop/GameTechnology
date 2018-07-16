using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour {

	int speedX;
	int speedY;

	float speed;

	//Score

	public Text scoreText;

	int player1Score;
	int player2Score;

	//winner
	public Text winner;

	public ParticleSystem sparks;

	// Use this for initialization
	void Start () {

		MoveBall ();
	}
	
	// Update is called once per frame
	void Update () {

		scoreText.text = player1Score.ToString() + " - " + player2Score.ToString();

		if (player1Score == 2){
			winner.text = "PLAYER 1 WIN";
			winner.gameObject.SetActive(true);
			ResetBall();
		}

		if (player2Score == 2)
        {
			winner.text = "PLAYER 2 WIN";
			winner.gameObject.SetActive(true);
			ResetBall();
        }
		
	}

	void MoveBall(){
		//scoreText.text = "test";

        speed = Random.Range(5, 10);

        // richtung
        speedX = Random.Range(0, 2);
        if(speedX == 0){
            speedX = 1;
        }else{
            speedX = -1;
        }

        speedY = Random.Range(0, 2);
        if (speedX == 0)
        {
            speedY = 1;
        }
        else
        {
            speedY = -1;
        }

        GetComponent<Rigidbody>().velocity = new Vector3(speed* speedX, speed* speedY, 0); // velocidad de la bola - velocidad*direccion
        
	}

	// Damit jedes Mal, wenn der Spieler einen Punk macht, wieder von vorne anfängt.
	void ResetBall(){
		transform.localPosition = new Vector3(0, 0, 0);
		GetComponent<Rigidbody>().velocity = Vector3.zero;
	}


	// Punktesumme der beiden Spieler
	void OnCollisionEnter(Collision goal){

		if (goal.collider.tag=="player1goal"){
			player1Score++;
			ResetBall ();
			Invoke("MoveBall",2); //Um der Methode mitzuteilen, wann und zu welcher Zeit sie aufgerufen werden soll
		}

		if (goal.collider.tag == "player2goal"){
            player2Score++;
			ResetBall ();
			Invoke("MoveBall", 2);
        }

		if (goal.collider.tag == "Player"){
			sparks.Play();
        }
	}

}

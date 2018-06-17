using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


//enumerator
public enum GameState { Idle, Playing, Ended, Ready};

public class GameController : MonoBehaviour {
    
	//Min and max bar
	[Range(0f, 0.20f)]
	public float ParallaxSpeed = 0.02f;
	public RawImage background;
	public RawImage platform;
	public GameObject UI_Idle;
	public GameObject UI_Score;
	public Text pointsText;
	public GameState gameState = GameState.Idle; //Idle

	public GameObject player;
	public GameObject enemyGenerator;

	private int points = 0;
   

	// Use this for initialization
	void Start () { 
		
	}
	
	// Update is called once per frame
	void Update () {

		//Spiel starten
		if (gameState == GameState.Idle && (Input.GetKeyDown("up") || Input.GetMouseButtonDown(0))){ //Pfeil nach oben oder Linke Maustaste 
			gameState = GameState.Playing;
			UI_Idle.SetActive(false); //nicht mehr aktiv
			UI_Score.SetActive(true);
			player.SendMessage("UpdateState", "PlayerRun");
			enemyGenerator.SendMessage("StartGenerator");
		}
		//Spiel läuft
		else if (gameState == GameState.Playing){
			Parallax();
		}
		//Spiel beendet und bereit zum Neustart
		else if (gameState == GameState.Ready){
			//RestartGame
			if (Input.GetKeyDown("up") || Input.GetMouseButtonDown(0)){
				RestartGame();
			}
        }
	}
	void Parallax(){
		float finalSpeed = ParallaxSpeed * Time.deltaTime;
        background.uvRect = new Rect(background.uvRect.x + finalSpeed, 0f, 1f, 1f);
        platform.uvRect = new Rect(platform.uvRect.x + finalSpeed * 4, 0f, 1f, 1f);
	}

	public void RestartGame(){
		SceneManager.LoadScene("Jump");
	}

	public void IncreasePoints(){
		points++;
		pointsText.text = points.ToString();
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GamePoints : MonoBehaviour
{

    public Text pointText;
    public Text gameOverText;

    private int _playerPoints = 0;
    private bool _gameOver;

    // Use this for initialization
    void Start()
    {
        if (gameOverText != null)
            gameOverText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (_gameOver)
        {
            if (Input.GetKey(KeyCode.R))
                Restart();
        }
    }

    public void AddPoints()
    {
        _playerPoints += 10;
        pointText.text = "Points: " + _playerPoints;
    }

    public void GameOver()
    {
        _gameOver = true;
        gameOverText.enabled = true;
    }

    private void Restart()
    {
        _gameOver = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }
}

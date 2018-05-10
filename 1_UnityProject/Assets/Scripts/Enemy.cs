using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	private float _enemySpeed;
	private GamePoints _gamePoints;

	// Use this for initialization
	void Start () {
		_gamePoints = GameObject.Find("GamePoints").GetComponent<GamePoints>();
		_enemySpeed = Random.Range(3, 10);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(new Vector3(1, 1, 1));
        transform.position -= new Vector3(0, _enemySpeed * Time.deltaTime, 0);

        if (transform.position.y < -5)
            Destroy(gameObject);
	}

	void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);

			if (_gamePoints != null)
				_gamePoints.GameOver();
        }
    }
}

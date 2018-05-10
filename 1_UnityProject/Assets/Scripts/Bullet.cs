using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    private float _speed = 20f;
	private GamePoints _gamePoints;

	// Use this for initialization
	void Start () {
		_gamePoints = GameObject.Find("GamePoints").GetComponent<GamePoints>();
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += new Vector3(0, Time.deltaTime * _speed, 0);
        if (transform.position.y > 20)
        {
            Destroy(gameObject);
        }
	}

	void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);

			if (_gamePoints != null)
				_gamePoints.AddPoints();
        }
    }
}

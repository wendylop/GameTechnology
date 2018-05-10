using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

	public float speed;
	private float _limitScreen = 10f;
	private float _timeToFire = 0;
	   
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		UpdateMovement();
		UpdateFire();
	}

	private void UpdateMovement()
	{
		if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
		{
			if (transform.position.x > _limitScreen) transform.position = new Vector3(-_limitScreen, transform.position.y, 0);

			transform.position += new Vector3(Time.deltaTime * speed, 0, 0);
		}
		else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
		{
			if (transform.position.x < -_limitScreen) transform.position = new Vector3(_limitScreen, transform.position.y, 0);

			transform.position -= new Vector3(Time.deltaTime * speed, 0, 0);
		}
	}

	private void UpdateFire()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            _timeToFire -= Time.deltaTime;
            if (_timeToFire <= 0)
            {
                Fire();
                _timeToFire = 0.2f;
            }
        }
    }

	private void Fire()
    {
		Instantiate(Resources.Load("Bullet"), new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
    }
}

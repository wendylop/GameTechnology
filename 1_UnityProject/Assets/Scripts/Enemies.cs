using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour {

	private float _initialYPosition = 15f;
	private float _launchTime;

	// Use this for initialization
	void Start () {
		_launchTime = Random.Range(1, 3);
	}
	
	// Update is called once per frame
	void Update () {
		_launchTime -= Time.deltaTime;
		if (_launchTime < 0)
			Launch();
	}

	private void Launch()
    {
        var XPosition = Random.Range(-10, 10);
		Instantiate(Resources.Load("Enemy"), new Vector3(XPosition, _initialYPosition, 0), Quaternion.identity);
		_launchTime = Random.Range(1, 3);
    }
}

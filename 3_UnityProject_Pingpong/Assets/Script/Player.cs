using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public KeyCode up;
	public KeyCode down;

	float speed;
	float finalspeed;

	// Use this for initialization
	void Start () {
		// Geschwindigkeit, mit der wir die Schaufel des Spielers bewegen.
		speed = 0.15f;
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKey(up)){// Wenn Sie die Aufwärtstaste drücken, sollten Sie das Paddel nach oben bewegen.

			if (transform.localPosition.y > 4 ){
				finalspeed = 0;
			} else {
				finalspeed = speed;
			}
		transform.Translate(0,finalspeed,0);	
		} 

		if (Input.GetKey(down)){ 
		
		    if (transform.localPosition.y < -4 ){
                finalspeed = 0;
            }else{
                finalspeed = speed;
            }
            transform.Translate(0,-finalspeed,0); 
        } 
        
	}
}

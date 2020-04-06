using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCollectable : MonoBehaviour {
	public float speed=1;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//transform.Rotate (0f,speed,0f,Space.Self);//We use spaceword so we can be sure that is rotating correctly through world cords
        transform.Rotate(0, 50 * Time.deltaTime, 0);//rotates 50 degrees per second around z axis
    }
}

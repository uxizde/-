using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Boid : MonoBehaviour {
	public int state = 0;
//	public Vector3 position;
	public Vector3 velocity;
	public float vlim = .05f;

	public void move(){
		transform.position = transform.position+velocity;
	}
}

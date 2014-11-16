﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Boid : MonoBehaviour {
	public int state = 1;
//	public Vector3 position;
	public Vector3 velocity;
	public float maxSpeed = .00025f;

	public void move(){
		transform.position = transform.position+velocity;
	}
}

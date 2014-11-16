using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Boid : MonoBehaviour {
	public int state = 1;
//	public Vector3 position;
	public Vector3 velocity;
	public int speed;

	public void move(){
		//position = position + velocity;
		//transform.position = position;
		transform.position = transform.position+velocity;
	}
	//public void Update(){
	//}
}

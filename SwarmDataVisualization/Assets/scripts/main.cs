//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AssemblyCSharp{
	public class main : MonoBehaviour {
		public GameObject Boid;
		public GameObject Predator;
		public List<GameObject> Boids;
		int numbBoids =50;
		public float dt = 0.005f;
		const float kCohesion = -0.01f;
		const float kSeperation = 0.0001f;
		const float kAlignment = -0.005f;

		public void Start(){
			Boids = new List<GameObject>();

			GameObject pred = (GameObject)Instantiate (Predator);
			pred.transform.position = new Vector3(-5f,0f,-5f);
			Predator p = pred.GetComponent<Predator>();
			p.velocity = new Vector3(0.08f,0.0f,0.08f);
			
			for(int i=0;i<numbBoids;i++){
				GameObject boid = (GameObject)Instantiate(Boid);
				boid.name = "boid"+i;
				float rand1 = (float)GetRandomNumber (-2.0,2.0);
				float rand2 = (float)GetRandomNumber (-2.0,2.0);
				float rand3 = (float)GetRandomNumber (-2.0,2.0);
				boid.transform.position = new Vector3(rand1, 0f, rand3);

				Boid b = boid.GetComponent<Boid>();
				rand1 = (float)GetRandomNumber (-.1,.1);
				rand2 = (float)GetRandomNumber (-.1,.1);
				rand3 = (float)GetRandomNumber (-.1,.1);
				b.velocity = new Vector3(rand1,0f,rand3);

				Boids.Add (boid);
			}

		}

		static System.Random random = new System.Random();
		public double GetRandomNumber(double minimum, double maximum){ 
			return random.NextDouble() * (maximum - minimum) + minimum;
		}

		public Vector3 cohesion(Boid boid){
			List<Vector3> positions = new List<Vector3> ();
			Vector3 thisPosition = boid.transform.position;
			Vector3 predPosition = Predator.transform.position;
			foreach (GameObject b in Boids) {
				Boid boids = b.GetComponent<Boid>();
				if (boids != boid)
					positions.Add (b.transform.position);
			}
			// positions now contain all positions of other boids
			Vector3 sumPosition = new Vector3 (0.0f, 0.0f, 0.0f);
			foreach (Vector3 position in positions) {
				sumPosition = sumPosition + position;
			}
			Vector3 positionCm = sumPosition / (Boids.Count-1);
			Vector3 distance = thisPosition - positionCm;
			Vector3 accel = new Vector3 (0.0f, 0.0f, 0.0f);
/*
			if(distance.sqrMagnitude < 80){
				//accel = distance / distance.sqrMagnitude;
				accel = distance / distance.magnitude;
			}
			else{ 
				accel = distance / 100;
			}
*/
			float kCohesion2 = -0.001f;
			if(distance.sqrMagnitude > 3&&(predPosition - thisPosition).magnitude >5){//if distance between boid and com is more then 3
			//	accel = distance / 100;
				accel = kCohesion*(distance / distance.sqrMagnitude) + kCohesion2*(distance / distance.magnitude);
			}
			else 
				accel = Vector3.zero;

			return accel;
		}
		public Vector3 seperation(Boid boid){
			List<Vector3> positions = new List<Vector3> ();
			Vector3 thisPosition = boid.transform.position;

			foreach (GameObject b in Boids) {
				Boid boids = b.GetComponent<Boid>();
				if (boids != boid)
					positions.Add (b.transform.position);
			}
			// positions now contain all positions of other boids
			List<Vector3> accelIs = new List<Vector3> ();
			foreach (Vector3 position in positions) {
				Vector3 distanceI = thisPosition - position;
				if(distanceI.magnitude < 5){//if distance between boids is less then 2
					Vector3 accelI = distanceI / distanceI.sqrMagnitude;
					accelIs.Add (accelI);
				}
			
			}
			// accelIs now contain all pseudo-separation-accelerations (not
			// multiplied with the constant) due to each of the other boids
			Vector3 sumAccelI = new Vector3 (0.0f, 0.0f, 0.0f);
			foreach (Vector3 accelI in accelIs) {
				sumAccelI = sumAccelI + accelI;
			}

			return kSeperation * sumAccelI;
			/*
			Vector3 acceleration = new Vector3 (0.0f, 0.0f, 0.0f);
			foreach (GameObject b in Boids) {
				Boid boids = b.GetComponent<Boid>();
				if (boids != boid){
					if((boid.transform.position - b.transform.position).magnitude<100){
						acceleration = acceleration - (boid.transform.position - b.transform.position);
					}
				}
			}
			return acceleration;*/
		}
		public Vector3 allignment(Boid boid){
			List<Vector3> velocities = new List<Vector3> ();
			Vector3 thisVelocity = boid.velocity;
			foreach (GameObject b in Boids) {
				Boid boids = b.GetComponent<Boid>();
				
				if (boids != boid)
					velocities.Add (boids.velocity);
			}
			// positions now contain all positions of other boids
			Vector3 sumVelocities = new Vector3 (0.0f, 0.0f, 0.0f);
			foreach (Vector3 velocity in velocities) {
				sumVelocities = sumVelocities + velocity;
			}
			Vector3 velocityCm = sumVelocities / (Boids.Count-1);
			Vector3 distance = thisVelocity - velocityCm;
			Vector3 accel = new Vector3 (0.0f, 0.0f, 0.0f);
			//if(distance.sqrMagnitude < 8000){
			//	accel = distance / distance.sqrMagnitude;
			//}
			//else{ 

			accel = kAlignment * distance;
			//}

			//Vector3 accel = distance / 100;
			return accel;
		}

		public void chasePrey(){

		}

		public void Update(){
			foreach(GameObject b in Boids){
				Boid boid = b.GetComponent<Boid>();
				Vector3 a1=cohesion (boid);
				Vector3 a2=seperation (boid);
				Vector3 a3=allignment (boid);
				boid.velocity = boid.velocity + a1*dt + a2*dt + a3*dt;
				float rand1 = (float)GetRandomNumber (-.01,.01);
				float rand2 = (float)GetRandomNumber (-.01,.01);
				float rand3 = (float)GetRandomNumber (-.01,.01);
				boid.velocity.x = boid.velocity.x + rand1;
				//boid.velocity.y = boid.velocity.y + rand2;
				boid.velocity.z = boid.velocity.z + rand3;
				boid.move();
			}
		}
	}
}


using UnityEngine;
using System.Collections;

<<<<<<< HEAD
<<<<<<< HEAD
public class Boid : MonoBehaviour {
	public int state = 1;
//	public Vector3 position;
	public Vector3 velocity;
	public int speed;

	public void move(){
		//position = position + velocity;
		//transform.position = position;
	}
	public void Update(){
		transform.position = new Vector3(transform.position.x + velocity.x, transform.position.y+velocity.y,transform.position.z+velocity.z);
		//move ();
	}
=======
public class Boid : MonoBehaviour
{
		Vector3 position;
		Vector3 velocity;
		Vector3 acceleration;
		const float kSeparation = 1.0f;
		const float kCohesion = -1.0f;

		public Boid (Vector3 position, Vector3 velocity)
		{
				this.position = position;
				this.velocity = velocity;
		}
	
		// Acceleration due to separation
		public Vector3 AccelSep (List<Boid> boids)
		{
				List<Vector3> positions = new List<Vector3> ();
				Vector3 thisPosition = this.position;
				foreach (Boid boid in boids) {
						if (boid != this)
								positions.Add (boid.position);
				}
				// positions now contain all positions of other boids
				List<Vector3> accelIs = new List<Vector3> ();
				foreach (Vector3 position in positions) {
						Vector3 distanceI = thisPosition - position;
						Vector3 accelI = distanceI * distanceI.sqrMagnitude;
						accelIs.Add (accelI);
				}
				// accelIs now contain all pseudo-separation-accelerations (not
				// multiplied with the constant) due to each of the other boids
				Vector3 sumAccelI = new Vector3 (0.0f, 0.0f, 0.0f);
				foreach (Vector3 accelI in accelIs) {
						sumAccelI = sumAccelI + accelI;
				}
				return kSeparation * sumAccelI;
		}
	
		public static void main ()
		{
				Boid boid0 = new Boid (new Vector3 (1.0f, 1.0f, 1.0f), new Vector3 (0.0f, 0.0f, 0.0f));
				Boid boid1 = new Boid (new Vector3 (2.0f, 1.0f, 3.0f), new Vector3 (0.0f, 0.0f, 0.0f));
				Boid boid2 = new Boid (new Vector3 (0.0f, 0.0f, 1.0f), new Vector3 (0.0f, 0.0f, 0.0f));
				List<Boid> boids = new List<Boid> ();
				boids.Add (boid0);
				boids.Add (boid1);
				boids.Add (boid2);
				System.Console.WriteLine (boid1.AccelSep (boids).x);
		}
>>>>>>> origin/master
=======
public class Boid : MonoBehaviour {
	public int state = 1;
	public Vector3 position { get; set; }
	public Vector3 velocity { get; set; }
>>>>>>> 9592994c57cf481f41575f7f81abfa86b5592928
}

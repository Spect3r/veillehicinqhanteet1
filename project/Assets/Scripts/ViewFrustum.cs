using UnityEngine;
using System.Collections;

public class ViewFrustum : MonoBehaviour {

	public float fieldOfViewAngle = 110f;
	public bool enemyInSight;
	//position of the enemy seen, usefull to alert the others
	public Vector2 personalLastSighting;


	//using to find the distance between this and the ennemy
	private NavMeshAgent nav;
	private SphereCollider col;
	private Transform lastEnemySighting;

	void Awake(){
		// Setting up the references.
		nav = GetComponent<NavMeshAgent>();
		col = GetComponent<SphereCollider>();
	}
	
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay(Collider other){
		if (other.gameObject.tag == "Enemy") {
			enemyInSight = false;

			Vector2 direction = other.transform.position - transform.position;
			float angle = Vector2.Angle(direction, transform.forward);

			if(angle < fieldOfViewAngle* 0.5f){
				RaycastHit2D hit;

				if(Physics2D.Raycast(transform.position, direction.normalized, col.radius));
				{
					if(hit.collider.gameObject.tag == "Enemy"){
						enemyInSight = true;
						Debug.Log("Enemy in sight !!");
						//lastEnemySighting.position = enemy.transform.position;
					}
				}
			}
		}
	}

	/*float CalculatePathLength (Vector3 targetPosition)
	{
		// Create a path and set it based on a target position.
		NavMeshPath path = new NavMeshPath();
		if(nav.enabled)
			nav.CalculatePath(targetPosition, path);
		
		// Create an array of points which is the length of the number of corners in the path + 2.
		Vector3[] allWayPoints = new Vector3[path.corners.Length + 2];
		
		// The first point is the enemy's position.
		allWayPoints[0] = transform.position;
		
		// The last point is the target position.
		allWayPoints[allWayPoints.Length - 1] = targetPosition;
		
		// The points inbetween are the corners of the path.
		for(int i = 0; i < path.corners.Length; i++)
		{
			allWayPoints[i + 1] = path.corners[i];
		}
		
		// Create a float to store the path length that is by default 0.
		float pathLength = 0;
		
		// Increment the path length by an amount equal to the distance between each waypoint and the next.
		for(int i = 0; i < allWayPoints.Length - 1; i++)
		{
			pathLength += Vector3.Distance(allWayPoints[i], allWayPoints[i + 1]);
		}
		
		return pathLength;
	}

	void OnTriggerExit (Collider other)
	{
		// If the player leaves the trigger zone...
		if(other.gameObject.tag == "Enemy")
			// ... the player is not in sight.
			playerInSight = false;
	}*/
}

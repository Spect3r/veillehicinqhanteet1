using UnityEngine;
using System.Collections;

public class Soldier : Ant {

	public Transform[] wayPoints;
	//public float speed;
	public int curWayPoint;
	public bool doPatrol = true;
	public Vector3 target;
	public Vector3 moveDirection;
	public Vector3 velocity;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		patrol ();

	}

	void patrol(){
		if (curWayPoint < wayPoints.Length) {
			target = wayPoints[curWayPoint].position;
			moveDirection = target - transform.position;
			velocity = rigidbody.velocity;
			
			if(moveDirection.magnitude < 1){
				curWayPoint++;
			}else{
				velocity = moveDirection.normalized * speed;
			}
		}
		else{
			if(doPatrol){
				curWayPoint = 0;
			}
			else{
				velocity = Vector3.zero;
			}
		}
		
		rigidbody.velocity = velocity;
		transform.LookAt (target);
	}

	void attack(){

	}
	public override void followPheromone ()
	{
		throw new System.NotImplementedException ();
	}

	public override void goToClosestGate(){

	}
	public override void goToQueen (){

	}
	public override void findFood(){

	}
	public override void putPheromone(){

	}

}


using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AntPatrolSoldier : Ant {

	/*public Transform[] wayPoints;
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
	
	}

	void patrol(){
		if (curWayPoint < wayPoints.Length) {
			target = wayPoints[curWayPoint].position;
			moveDirection = target - transform.position;
			velocity = rigidbody2D.velocity;
			
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
		
		rigidbody2D.velocity = velocity;
		transform.LookAt (target);
	}*/

	protected override Collider2D[] getPerception(){
		return Physics2D.OverlapCircleAll(this.transform.position, 3f);
	}
	
	protected override List<Action> makeDecision(Collider2D[] perceptions){
		List<Action> actions = new List<Action>();
		/*foreach (Collider2D collider in perceptions) {
			/*if(isEnemy(collider)){
				actions.Add(new Action("attack", enemy));
				actions.Add(new Action("putPheromone", pheromoneDanger));
			}else{
				patrol();
			}
		}*/
		return actions;
	}
	
	protected override Vector2 applyAction(List<Action> actions) {
		return new Vector2();
	}
	protected override void move(Vector2 direction) {
	
	}
}

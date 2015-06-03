using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public sealed class AntWorker : Ant {

	public GameObject target;
	public GameObject warningPheromone;
	public GameObject foodPheromone;
	private bool foodOn = false;
	private GameObject gate;
	private GameObject warehouse;

	void Awake(){
		gate = GameObject.FindGameObjectWithTag ("Gate");
		warehouse = new GameObject();//GameObject.FindGameObjectWithTag ("Warehouse");
	}

	/*public void findFood(){
		GameObject closestFood = GetClosestObject ("Food");
		//Debug.Log("Closest Object is " + closestFood.name);
		this.target = closestFood;
		int foodPoint = closestFood.gameObject.GetComponent<Food> ().foodPoint;
		transform.position = Vector3.MoveTowards(transform.position, target.transform.position, 0.03f);
		if (target.transform.position == this.transform.position) {
			if(foodPoint <= 0){
				Destroy(target);
			} else {
				foodPoint = foodPoint - 1;}
			InvokeRepeating ("putPheromone", 0, 2);
			behaviour = "GoToQueen";
			goToQueen();
		}
	}

	public void goToQueen (){
		GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Queen");
		GameObject queen = objectsWithTag [0];
		this.target = queen;
		transform.position = Vector3.MoveTowards(transform.position, target.transform.position, 0.03f);
		if (target.transform.position == this.transform.position) {
			CancelInvoke("putPheromone");
			behaviour = "FindFood";
		}
	}

	public void putPheromone(){
		Instantiate (foodPheromone, this.transform.position, Quaternion.identity);
	}

	public void deletePheromone(GameObject pheromone)
	{
		Destroy (pheromone);
	}*/
	

	protected override Collider2D[] getPerception() {
		return Physics2D.OverlapCircleAll(this.transform.position, 3f);
	}



	protected override List<Action> makeDecision(Collider2D[] perceptions){
		List<Action> actions = new List<Action>();
		foreach(Collider2D collider in perceptions){
			if(isEnemy(collider.gameObject)){
				actions.Add(new Action("flee", collider.gameObject));
				actions.Add(new Action("putPheromone", warningPheromone));
			} 
			else
			{
				if(foodOn == true){
					if(this.transform.position == gateA.transform.position){
						actions.Add(new Action("teleportation", gateB));
						actions.Add(new Action("seek", warehouse));
					}
					else{
						actions.Add(new Action("seek", gateA));
					}
				}
				else{
					if(isFood(collider.gameObject)){
						if(collider.transform.position == this.transform.position){
							actions.Add(new Action("takeFood", collider.gameObject));
							actions.Add(new Action("putPheromone", foodPheromone));
						}
						else{
							actions.Add(new Action("seek", collider.gameObject));
						}
					}
					else{
						if(isPheromone(collider.gameObject)){
							if(this.transform.position == collider.transform.position){
								actions.Add(new Action("deletePheromone", collider.gameObject));
							}
							else{
								actions.Add(new Action("seek", foodPheromone));
							}
						}
						else{
							actions.Add(new Action("Wandering", null));
						}
					}
					
				}		
					
			}
		}
		return actions;
	}

	protected override Vector2 applyAction(List<Action> actions)
	{
		Vector2 direction = new Vector2 (1f,1f);
		foreach(Action action in actions)
		{
			/*if(action.getBehaviour() == "seek")
			{
				direction += SeekBehaviour.run(action.getTarget());
			}
			if(action.getBehaviour() == "flee")
			{
				direction += FleeBehaviour.run(action.getTarget());
			}
			if(action.getBehaviour() == "wandering")
			{
				direction += Wandering.run();
			}
			if(action.getBehaviour() == "teleportation")
			{
				this.transform.position = gateB.transform.position;
			}
			if(action.getBehaviour() == "putPheromone")
			{
				this.putPheromone();
			}
			if(action.getBehaviour() == "deletePheromone")
			{
				this.deletePheromone();
			}*/
		}
		return direction;
	}

	protected override void move(Vector2 direction)
	{
		// Kinematic movement
		rigidbody2D.velocity = direction.normalized * speed;
		
		// Orientation
		if(rigidbody2D.velocity.magnitude > 0) {
			
			Vector3 referenceForward = new Vector3(-1,0,0);
			
			float angle = Vector3.Angle(referenceForward, direction);
			
			float sign = Mathf.Sign(Vector3.Dot(new Vector3(0,1,0),direction));
			
			transform.rotation = Quaternion.Euler(new Vector3(0,0,angle * -sign));
			
		}
	}
		

}




using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Worker : Ant, AbstractAgent {

	public GameObject target;
	public GameObject warningPheromone;
	public GameObject foodPheromone;
	private bool foodOn = false;
	private GameObject[] gates;
	private GameObject[] warehouse;


	void Awake(){
		gates = GameObject.FindGameObjectsWithTag ("Gate");
		warehouse = GameObject.FindGameObjectWithTag ("Warehouse");
	}

	// Use this for initialization
	void Start () {
		//findFood ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void findFood(){
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
	}
	

	Collider2D[] getPerception(){
		Collider2D[] perceptions = Physics2D.OverlapCircleAll(transform.position, 3f);
	}



	List<Action> makeDecision(Collider2D[] perceptions){
		List<Action> actions;
		foreach(Collider2D collider in perceptions){
			if(isEnemy(collider)){
				actions.Add(new Action("flee", collider));
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
					if(isFood(collider)){
						if(Food.transform.position == this.transform.position){
							actions.Add(new Action("takeFood", collider));
							actions.Add(new Action("putPheromone", foodPheromone));
						}
						else{
							actions.Add(new Action("seek", collider));
						}
					}
					else{
						if(isPheromone(collider)){
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
	}

	Vector2 applyAction(List<Action> actions)
	{
		Vector2 direction = new Vector2 ();
		foreach(Action action in actions)
		{
			if(action.getBehaviour() == "seek")
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
			}
		}
		return direction;
	}

	void move(Vector2 direction)
	{
		this.rigidbody2D.AddForce (direction);
	}
		

}




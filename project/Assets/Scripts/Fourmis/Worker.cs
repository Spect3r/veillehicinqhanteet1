using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Worker : Ant, AbstractAgent {

	public GameObject target;
	public GameObject pheromone;
	private bool foodOn = false;
	private GameObject[] gates;

	void Awake(){
		gates = GameObject.FindGameObjectsWithTag ("Gate");
	}

	// Use this for initialization
	void Start () {
		//findFood ();
	}
	
	// Update is called once per frame
	void Update () {
		if (behaviour == "GoToQueen") {
			goToQueen ();
		} else {
			findFood ();
		}
		/*if (behaviour != "OK") {
			goToClosestGate ();	
		}*/



		/*if (target.transform.position == this.transform.position) {
			behaviour = "SearchFood";
			findFood();
		}*/
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
		Instantiate (pheromone, this.transform.position, Quaternion.identity);
	}

	Collider2D[] getPerception(){
		perceptions = Physics2D.OverlapCircleAll(transform.position, 3f);
	}



	List<Action> makeDecision(){
		List<Action> actions;
		foreach(Collider2D collider in perceptions){
			if(isEnemy(collider)){
				actions.Add(new Action("flee", enemy));
				actions.Add(new Action("putWarningPheromone"));
			} 
			else
			{
				if(foodOn == true){
					if(this.transform.position == gateA.transform.position){
						actions.Add(new Action("enterColony", gateB));
						actions.Add(new Action("goToWarehouse", warehouse));
					}
					else{
						actions.Add(new Action("goToColony", gateA));
					}
				}
				else{
					if(isFood(collider)){
						if(Food.transform.position == this.transform.position){
							actions.Add(new Action("takeFood", gateB));
							actions.Add(new Action("putPheromone", warehouse));
						}
						else{
							actions.Add(new Action("goToFood", food));
						}
					}
					else{
						if(isPheromone(collider)){
							if(this.transform.position == pheromone.transform.position){
								actions.Add(new Action("deletePheromone", pheromone));
							}
							else{
								actions.Add(new Action("goToPheromone", pheromone));
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
		

}




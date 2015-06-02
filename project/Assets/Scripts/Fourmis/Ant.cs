using UnityEngine;
using System.Collections;

public class Ant : Insect {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void goToClosestGate(){
		GameObject closestGate = GetClosestObject("Gate");
		transform.position = Vector3.MoveTowards(transform.position, closestGate.transform.position, 0.03f);
		if (transform.position == closestGate.transform.position) {
			if(closestGate.name == "GateA"){
				transform.position = gateB.transform.position;
			} else {
				transform.position = gateA.transform.position;
			}
			
		}
	}

	public bool isEnemy(GameObject enemy){
		if (enemy.tag == "Spider" || enemy.tag == "Termite")
				return true;
		else
				return false;
	}

	public bool isFood(GameObject food){
		if (food.tag == "Food")
			return true;
		else
			return false;
		
	}

	public void isPheromone(GameObject pheromone){
		if (pheromone.tag == "FoodPheromone" || pheromone.tag == "WarningPheromone")
			return true;
		else
			return false;
	}
}

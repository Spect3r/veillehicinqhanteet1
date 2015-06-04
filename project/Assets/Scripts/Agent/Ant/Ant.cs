using UnityEngine;
using System.Collections;

public abstract class Ant : Insect {

	// Ant Knowledge
	protected GameObject homeIn;
	protected GameObject homeOut;
	
	void Awake(){
		homeIn = GameObject.FindGameObjectWithTag ("AntHomeIn");
		homeOut = GameObject.FindGameObjectWithTag ("AntHomeOut");
	}

	/*
	A mettre dans un comportement ?
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
	}*/

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

	public bool isPheromone(GameObject pheromone){
		if (pheromone.tag == "FoodPheromone" || pheromone.tag == "WarningPheromone")
			return true;
		else
			return false;
	}
}

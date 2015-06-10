using UnityEngine;
using System.Collections;

public abstract class Termite : Insect {
	
	// Ant Knowledge
	protected GameObject homeIn;
	protected GameObject homeOut;
	protected GameObject warehouse;
		
	protected bool isHome = true;
	
	
	void Awake(){
		homeIn = GameObject.FindGameObjectWithTag ("TermiteHomeIn");
		homeOut = GameObject.FindGameObjectWithTag ("TermiteHomeOut");
		warehouse = GameObject.FindGameObjectWithTag ("TermiteWarehouse");
	}
	
	
	public bool isEnemy(GameObject enemy){
		if (enemy.tag == "AntSoldier" || enemy.tag == "AntWorker" || enemy.tag == "SpiderDigger" || enemy.tag == "SpiderWanderer")
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
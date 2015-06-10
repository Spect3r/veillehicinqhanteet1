﻿using UnityEngine;
using System.Collections;

public abstract class Ant : Insect {

	// Ant Knowledge
	protected GameObject homeIn;
	protected GameObject homeOut;
	protected GameObject warehouse;	
	
	protected bool isHome = true;
	
	
	void Awake(){
		homeIn = GameObject.FindGameObjectWithTag ("AntHomeIn");
		homeOut = GameObject.FindGameObjectWithTag ("AntHomeOut");
		warehouse = GameObject.FindGameObjectWithTag ("AntWarehouse");
	}
	

	public bool isEnemy(GameObject enemy){
		if (enemy.tag == "SpiderDigger" || enemy.tag == "SpiderWanderer" || enemy.tag == "TermiteWorker" || enemy.tag == "TermiteSoldier")
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

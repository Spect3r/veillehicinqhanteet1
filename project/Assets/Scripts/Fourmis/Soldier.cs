﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Soldier : Ant, AbstractAgent {

	private int strength = 2;
	private int life = 6;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}
	
	void attack(Insect target){
		target.life -= this.strength;
	}

	void isPheromone(){

	}

	Collider2D[] getPerception(){
		Collider2D[] perceptions = Physics2D.OverlapCircleAll(transform.position, 3f);
	}
	
	
	
	List<Action> makeDecision(Collider2D perceptions){
		List<Action> actions;
		foreach(Collider2D collider in perceptions){
			GameObject gameObject = collider.gameObject;
			if(isEnemy(gameObject)){
				actions.Add(new Action("attack", collider));
				actions.Add(new Action("putPheromone", null));
			}
			else{
					if(isPheromone(collider)){
						actions.Add(new Action("seek", collider));
					}else{
						actions.Add(new Action("wandering", null));
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

}
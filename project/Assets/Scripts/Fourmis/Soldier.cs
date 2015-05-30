using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Soldier : Ant, AbstractAgent {
	
	//public float speed;
	public Vector3 target;
	public Vector3 moveDirection;
	public Vector3 velocity;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}



	void attack(){

	}

	Collider2D[] getPerception(){
		perceptions = Physics2D.OverlapCircleAll(transform.position, 3f);
	}
	
	
	
	List<Action> makeDecision(){
		List<Action> actions;
		foreach(Collider2D collider in perceptions){
			if(isEnemy(collider)){
				actions.Add(new Action("attack", collider));
				actions.Add(new Action("putPheromone", null));
			}
			else{
					if(isPheromone(collider)){
						actions.Add(new Action("goToPheromone", collider));
					}else{
						actions.Add(new Action("wandering", null));
					}	
			}
	
		}

	}

}
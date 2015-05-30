using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spider : AbstractAgent {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	Collider2D getPerception(){
		perceptions = Physics2D.OverlapCircleAll(transform.position, 3f);
	}

	List<Action> makeDecision(){
		List<Action> actions;
		if(perceptions[i] == enemy){
			actions.Add(new Action("attack", enemy));
		} else {
			actions.Add(new Action("wandering", null));
		}
	}
}

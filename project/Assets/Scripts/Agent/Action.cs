using UnityEngine;
using System.Collections;

public class Action {
	
	private string behaviour;
	private GameObject target;
	
	public Action(string behaviour, GameObject target) {
		this.behaviour = behaviour;
		this.target = target;
	}
	
	public string getBehaviour() {
		return this.behaviour;
	}
	
	public GameObject getTarget() {		
		return this.target;
	}
}


using UnityEngine;
using System.Collections;

public class Action {
	
	private string behaviour;
	private Collider2D target;
	
	public Action(string behaviour, Collider2D target) {
		this.behaviour = behaviour;
		this.target = target;
	}
	
	public string getBehaviour() {
		return this.behaviour;
	}
	
	public Collider2D getTarget() {		
		return this.target;
	}
}


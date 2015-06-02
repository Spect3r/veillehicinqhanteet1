using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class AbstractAgent {

	Collider2D[] perceptions;
	List<Action> actions = new List<Action>();

	public SeekBehaviour SeekBehaviour;
	public FleeBehaviour FleeBehaviour;
	public Wandering Wandering;

	void Update () {
		/* Perceptions and decisions */
		if(Simulateur.state == true) {
			//Debug.Log(name + " - Emit Influence !");
			
			// Perception
			perceptions = getPerception();
			// Decision making
			actions = makeDecision(perceptions);
			
		}
		/* Apply actions */
		else {
			//Debug.Log(name + " - Apply Influence !");
			
			// Apply behavior foreach actions
			Vector2 direction = applyAction(actions);
			
			// Move agent
			move(direction);
		}
	}
	
	Collider2D[] getPerception();
	List<Action> makeDecision(Collider2D[] perceptions);
	
	Vector2 applyAction(List<Action> actions);
	void move(Vector2 direction);
}


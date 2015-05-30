using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class AbstractAgent {

	Collider2D[] perceptions;
	List<Action> actions = new List<Action>();

	void Update () {
		/* Perceptions and decisions */
		if(Simulateur.state == true) {
			//Debug.Log(name + " - Emit Influence !");
			
			// Perception
			perceptions = getPerception();
			// Decision making
			actions = makeDecision();
			
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
	List<Action> makeDecision();
	
	Vector2 applyAction(List<Action> actions);
	void move(Vector2 direction);
}


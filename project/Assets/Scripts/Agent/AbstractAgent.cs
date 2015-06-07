using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class AbstractAgent : MonoBehaviour {

	private Collider2D[] perceptions;
	private List<Action> actions = new List<Action>();
	
	void Start () {
		initialisation();
	}
	
	protected virtual void initialisation() {}

	void Update () {
		/* Perceptions and decisions */
		if(Simulator.state == true) {
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
	
	protected abstract Collider2D[] getPerception();
	protected abstract List<Action> makeDecision(Collider2D[] perceptions);
	
	protected abstract Vector2 applyAction(List<Action> actions);
	protected abstract void move(Vector2 direction);
}


using UnityEngine;
using System.Collections;

public abstract class Insect : AbstractAgent {
	
	// Caracteristics
	public int speed;
	public int life;
	public int strengh;
	
	// Behaviour
	protected SeekBehaviour seekBehaviour = new SeekBehaviour();
	protected FleeBehaviour fleeBehaviour = new FleeBehaviour();
	protected Wandering wandering = new Wandering();

	bool isGate(GameObject gameObject) {
		if (gameObject.tag == "Gate")
			return true;
		else
			return false;
	}
}

using UnityEngine;
using System.Collections;

public abstract class Insect : AbstractAgent {
	
	// Caracteristics
	public int speed;
	public int life;
	public int strengh;
	
	// Behaviour
	public SeekBehaviour SeekBehaviour;
	public FleeBehaviour FleeBehaviour;
	public Wandering Wandering;

	bool isGate(GameObject gameObject) {
		if (gameObject.tag == "Gate")
			return true;
		else
			return false;
	}
}

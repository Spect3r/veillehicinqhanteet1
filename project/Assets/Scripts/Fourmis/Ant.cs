using UnityEngine;
using System.Collections;

public abstract class Ant : Insect {

	public abstract override void goToClosestGate();
	public abstract override void goToQueen ();
	public abstract override void findFood();
	public abstract void putPheromone();
	protected Pheromone ant_pheromone;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

}

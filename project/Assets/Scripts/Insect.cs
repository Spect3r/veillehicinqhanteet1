using UnityEngine;
using System.Collections;

public abstract class Insect : MonoBehaviour {

	public int speed;
	public string behaviour;
	public GameObject gateA;
	public GameObject gateB;
	public string espece;
	/*
	// Use this for initialization
	void Start () {
		SeekBehaviour seekBehaviour = GetComponent<SeekBehaviour>();
		behaviour = "Wandering";

	}
	
	// Update is called once per frame
	void Update () {
		//randomMove ();
		/*if(behaviour == "SeekBehaviour"){
			seekBehaviour.
		}*//*
	
	}
*/
	/*public void randomMove(){

		transform.Translate(1,0,0);
		
	}*/

	public abstract void followPheromone();

	public abstract void goToClosestGate();
	public abstract void goToQueen ();
	public abstract void findFood();
	

}

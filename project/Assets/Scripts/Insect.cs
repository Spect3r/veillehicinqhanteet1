using UnityEngine;
using System.Collections;

public class Insect : MonoBehaviour {

	public int speed;
	public string behaviour;
	public GameObject gateA;
	public GameObject gateB;

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
		}*/
	
	}

	/*public void randomMove(){

		transform.Translate(1,0,0);
		
	}*/

	public void followPheromone(){

	}


}

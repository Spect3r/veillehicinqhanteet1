using UnityEngine;
using System.Collections;

public class Insect : MonoBehaviour {

	public int speed;
	public string behaviour;

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


}

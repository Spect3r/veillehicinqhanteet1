using UnityEngine;
using System.Collections;

public class Agent : MonoBehaviour {

	//public Espece = fourmis;
	//public classe = worker;
	

	// Use this for initialization
	void Start () {
		//Insect i = new fourmi worker
	}
	
	// Update is called once per frame
	void Update () {
		if(Simulateur.state == true) {
			Debug.Log(name + " - Emit Influence !");
			takeRandTime();
			
			// getPerception
			//if.perception
			// decision making
			//i.decision
			// emit influence
			//if.emit
		}
		else {
			Debug.Log(name + " - Apply Influence !");
			takeRandTime();
			
			// take action and do behavior
			
			// move (vector direction)
		}
	}
	
	void takeRandTime() {
		
		int iterations = Random.Range(0,3);
		for(int i =0; i < iterations; i++) {
			Debug.Log("");
		}
	}
	
}

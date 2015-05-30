using UnityEngine;
using System.Collections;

public class syncInUpdate : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
	
		Debug.Log(name + " - Emit Influence !");
		
		Simulateur.numberOfAgentReady++;
		
		while(true) {
			if(Simulateur.numberOfAgentReady == Simulateur.numberOfAgent)
				break;
		}
		
		Debug.Log(name + " - Apply Influence !");
	}
}

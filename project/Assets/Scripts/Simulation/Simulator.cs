using UnityEngine;
using System.Collections;

public class Simulator : MonoBehaviour {
	
	public static bool state = false;
	public static bool running = true;
	
	// Update is called once per frame
	void LateUpdate () {
		
		if(running) {
			if(state == false)
				state = true;
			else 
				state = false;
		}		
	}
}

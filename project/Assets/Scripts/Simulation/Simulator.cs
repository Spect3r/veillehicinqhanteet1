using UnityEngine;
using System.Collections;

public class Simulator : MonoBehaviour {
	
	public static bool state = false;
	
	// Update is called once per frame
	void LateUpdate () {
		
		if(state == false)
			state = true;
		else 
			state = false;
	}
}

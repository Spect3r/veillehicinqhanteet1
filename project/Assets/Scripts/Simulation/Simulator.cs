using UnityEngine;
using System.Collections;

public class Simulator : MonoBehaviour {
	
	public static float numberOfAgent = 10;
	public static float numberOfAgentReady = 0;
	
	public static bool state = false;
	
	// Update is called once per frame
	void LateUpdate () {
		
		if(state == false)
			state = true;
		else 
			state = false;
			
		numberOfAgentReady = 0;	
	}
}

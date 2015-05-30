using UnityEngine;
using System.Collections;

public class Simulator : MonoBehaviour {
	
	public GameObject queen;
	public GameObject food;
	public GameObject worker;
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

	// Use this for initialization
	void Start () {

		for (int i = 0; i<20; i++) {
			Vector3 position = new Vector3(Random.Range(-10.0F, 10.0F), Random.Range(-10.0F, 10.0F));		
			Instantiate (food, position, Quaternion.identity);
			
		}

		for (int i = 0; i<20; i++) {
			Vector3 position = new Vector3(Random.Range(-10.0F, 10.0F), Random.Range(-10.0F, 10.0F));		
			Instantiate (worker, position, Quaternion.identity);
			
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

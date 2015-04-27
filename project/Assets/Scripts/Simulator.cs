using UnityEngine;
using System.Collections;

public class Simulator : MonoBehaviour {
	
	public GameObject insect;
	public GameObject food;
	public GameObject worker;

	// Use this for initialization
	void Start () {
		for (int i = 0; i<30; i++) {
			Vector3 position = new Vector3(Random.Range(-10.0F, 10.0F), Random.Range(-10.0F, 10.0F));
			Quaternion orientation = Random.rotation;
			orientation.x = 0;
			orientation.y = 0;

			Instantiate (insect, position, orientation);

		}

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

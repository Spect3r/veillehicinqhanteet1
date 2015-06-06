using UnityEngine;
using System.Collections;

public class EntitySpawn : MonoBehaviour {
	
	public GameObject queen;
	public GameObject food;
	public GameObject worker;
	
	void Start () {

		for (int i = 0; i<20; i++) {
			Vector2 position = new Vector2(Random.Range(-25.0F, 25.0F), Random.Range(-25.0F, 25.0F));		
			//Instantiate (food, position, Quaternion.identity);			
		}

		for (int i = 0; i<40; i++) {
			// Random position
			Vector2 position = new Vector2(Random.Range(-10.0F, 10.0F), Random.Range(-10.0F, 10.0F));
			
			// Random orientation
			Quaternion orientation = Quaternion.AngleAxis(Random.Range(-180f,180f), new Vector3(0f,0f,1f));
					
			Instantiate (worker, position, orientation);			
		}
	}
}

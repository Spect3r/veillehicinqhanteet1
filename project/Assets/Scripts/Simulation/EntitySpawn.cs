using UnityEngine;
using System.Collections;

public class EntitySpawn : MonoBehaviour {
	
	public GameObject queen;
	public GameObject food;
	public GameObject worker;
	
	void Start () {

		for (int i = 0; i<20; i++) {
			Vector2 position = new Vector2(Random.Range(-15.0F, 15.0F), Random.Range(-15.0F, 15.0F));		
			Instantiate (food, position, Quaternion.identity);			
		}

		for (int i = 0; i<20; i++) {
			Vector2 position = new Vector2(Random.Range(-10.0F, 10.0F), Random.Range(-10.0F, 10.0F));		
			Instantiate (worker, position, Quaternion.identity);			
		}
	}
}

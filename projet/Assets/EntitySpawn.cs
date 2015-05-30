using UnityEngine;
using System.Collections;

public class EntitySpawn : MonoBehaviour {

	public GameObject ant;

	// Use this for initialization
	void Start () {
		
		for(int i=-20; i <= 20; i+=10) {
			for(int y=-20; y <= 20; y+=10) {
				Instantiate(ant, ant.transform.position + new Vector3(i,0,y), ant.transform.rotation);			
			}
		}
	}
}

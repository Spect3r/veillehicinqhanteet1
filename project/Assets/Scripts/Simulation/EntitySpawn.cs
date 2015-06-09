using UnityEngine;
using System.Collections;

public class EntitySpawn : MonoBehaviour {
	
	public GameObject queen;
	public GameObject food;
	public GameObject worker;
	public GameObject antSoldier;
	public GameObject antQueen;
	public GameObject spiderWanderer;
	public GameObject spiderDigger;
	
	void Start () {
		
		/** Food **/
		for (int i = 0; i<20; i++) {
			Vector2 position = new Vector2(Random.Range(-25.0F, 25.0F), Random.Range(-25.0F, 25.0F));		
			Instantiate (food, position, Quaternion.identity);			
		}
		
		/** Ant **/
		GameObject antHome = GameObject.FindGameObjectWithTag("AntHome");
		Vector2 antHomePosition = new Vector2(antHome.transform.position.x, antHome.transform.position.y);
		
		for (int i = 0; i<20; i++) {
			// Random position
			Vector2 position = Random.insideUnitCircle * 10f + antHomePosition;
			
			// Random orientation
			Quaternion orientation = Quaternion.AngleAxis(Random.Range(-180f,180f), Vector3.forward);
					
			Instantiate (worker, position, orientation);			
		}
		for (int i = 0; i<20; i++) {
			// Random position
			Vector2 position = Random.insideUnitCircle * 10f + antHomePosition;
				
			// Random orientation
			Quaternion orientation = Quaternion.AngleAxis(Random.Range(-180f,180f), Vector3.forward);
			
			Instantiate (antSoldier, position, orientation);			
		}
		/*for (int i = 0; i<1; i++) {
			// Random position
			Vector2 position = new Vector2(414.0f,18.0f);
			
			// Random orientation
			Quaternion orientation = Quaternion.AngleAxis(Random.Range(-180f,180f), Vector3.forward);
			
			Instantiate (antQueen, position, orientation);			
		}*/
		
		/** Spider **/		
		for (int i = 0; i<5; i++) {
			// Random position
			Vector2 position = new Vector2(Random.Range(-25.0F, 25.0F), Random.Range(-25.0F, 25.0F));
			
			// Random orientation
			Quaternion orientation = Quaternion.AngleAxis(Random.Range(-180f,180f), Vector3.forward);
			
			Instantiate (spiderWanderer, position, orientation);			
		}
		for (int i = 0; i<5; i++) {
			// Random position
			Vector2 position = new Vector2(Random.Range(-22.0F, 22.0F), Random.Range(-22.0F, 22.0F));
			
			// Random orientation
			Quaternion orientation = Quaternion.AngleAxis(Random.Range(-180f,180f), Vector3.forward);
			
			Instantiate (spiderDigger, position, orientation);	
		}
	}
}

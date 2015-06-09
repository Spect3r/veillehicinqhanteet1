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
		
		GameObject ground = GameObject.FindGameObjectWithTag("Ground");
		Vector2 groundPosition = new Vector2(ground.transform.position.x, ground.transform.position.y);
		
		/** Food **/
		for (int i = 0; i<50; i++) {
			Vector2 position = new Vector2(Random.Range(-50.0F, 50.0F), Random.Range(-50.0F, 50.0F)) + groundPosition;		
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
			
			Statistics.addInsect("AntWorker");
		}
		for (int i = 0; i<20; i++) {
			// Random position
			Vector2 position = Random.insideUnitCircle * 10f + antHomePosition;
				
			// Random orientation
			Quaternion orientation = Quaternion.AngleAxis(Random.Range(-180f,180f), Vector3.forward);
			
			Instantiate (antSoldier, position, orientation);
			
			Statistics.addInsect("AntSoldier");
		}
		/*for (int i = 0; i<1; i++) {
			// Random position
			Vector2 position = new Vector2(414.0f,18.0f);
			
			// Random orientation
			Quaternion orientation = Quaternion.AngleAxis(Random.Range(-180f,180f), Vector3.forward);
			
			Instantiate (antQueen, position, orientation);			
		}*/
		
		/** Spider **/		
		for (int i = 0; i<25; i++) {
			// Random position
			Vector2 position = new Vector2(Random.Range(-50.0F, 50.0F), Random.Range(-50.0F, 50.0F)) + groundPosition;
			
			// Random orientation
			Quaternion orientation = Quaternion.AngleAxis(Random.Range(-180f,180f), Vector3.forward);
			
			Instantiate (spiderWanderer, position, orientation);
			
			Statistics.addInsect("SpiderWanderer");			
		}
		for (int i = 0; i<15; i++) {
			// Random position
			Vector2 position = new Vector2(Random.Range(-50.0F, 50.0F), Random.Range(-50.0F, 50.0F)) + groundPosition;
			
			// Random orientation
			Quaternion orientation = Quaternion.AngleAxis(Random.Range(-180f,180f), Vector3.forward);
			
			Instantiate (spiderDigger, position, orientation);
			
			Statistics.addInsect("SpiderDigger");
		}
	}
}

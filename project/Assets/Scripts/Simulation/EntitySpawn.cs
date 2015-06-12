using UnityEngine;
using System.Collections;

public class EntitySpawn : MonoBehaviour {
	
	public GameObject food;
	
	public GameObject antWorker;
	public GameObject antSoldier;
	
	public GameObject termiteWorker;
	public GameObject termiteSoldier;
	
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
		
		for (int i = 0; i<50; i++) {
			// Random position
			Vector2 position = Random.insideUnitCircle * 10f + antHomePosition;
			
			// Random orientation
			Quaternion orientation = Quaternion.AngleAxis(Random.Range(-180f,180f), Vector3.forward);
					
			Instantiate (antWorker, position, orientation);
			
			Statistics.addInsect("AntWorker");
		}
		for (int i = 0; i<50; i++) {
			// Random position
			Vector2 position = Random.insideUnitCircle * 10f + antHomePosition;
				
			// Random orientation
			Quaternion orientation = Quaternion.AngleAxis(Random.Range(-180f,180f), Vector3.forward);
			
			Instantiate (antSoldier, position, orientation);
			
			Statistics.addInsect("AntSoldier");
		}
		
		/** Termite **/
		GameObject termiteHome = GameObject.FindGameObjectWithTag("TermiteHome");
		Vector2 termiteHomePosition = new Vector2(termiteHome.transform.position.x, termiteHome.transform.position.y);
		
		for (int i = 0; i<50; i++) {
			// Random position
			Vector2 position = Random.insideUnitCircle * 10f + termiteHomePosition;
			
			// Random orientation
			Quaternion orientation = Quaternion.AngleAxis(Random.Range(-180f,180f), Vector3.forward);
			
			Instantiate (termiteWorker, position, orientation);
			
			Statistics.addInsect("TermiteWorker");
		}
		for (int i = 0; i<50; i++) {
			// Random position
			Vector2 position = Random.insideUnitCircle * 10f + termiteHomePosition;
			
			// Random orientation
			Quaternion orientation = Quaternion.AngleAxis(Random.Range(-180f,180f), Vector3.forward);
			
			Instantiate (termiteSoldier, position, orientation);
			
			Statistics.addInsect("TermiteSoldier");
		}
		
		/** Spider **/		
		for (int i = 0; i<90; i++) {
			// Random position
			Vector2 position = new Vector2(Random.Range(-50.0F, 50.0F), Random.Range(-50.0F, 50.0F)) + groundPosition;
			
			// Random orientation
			Quaternion orientation = Quaternion.AngleAxis(Random.Range(-180f,180f), Vector3.forward);
			
			Instantiate (spiderWanderer, position, orientation);
			
			Statistics.addInsect("SpiderWanderer");			
		}
		for (int i = 0; i<10; i++) {
			// Random position
			Vector2 position = new Vector2(Random.Range(-40.0F, 40.0F), Random.Range(-40.0F, 40.0F)) + groundPosition;
			
			// Random orientation
			Quaternion orientation = Quaternion.AngleAxis(Random.Range(-180f,180f), Vector3.forward);
			
			Instantiate (spiderDigger, position, orientation);
			
			Statistics.addInsect("SpiderDigger");
		}
	}
}

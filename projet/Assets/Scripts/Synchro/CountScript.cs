using UnityEngine;
using System.Collections;

public class CountScript : MonoBehaviour {
	
	//private float count = 0;
	
	
	private static float numberOfAgent = 10;
	private static float numberOfAgentWhoEmitedInfluence = 0;
	private static float numberOfAgentWhoAppliedAction = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//Debug.Log(name + " - Start !");
		
		/*Debug.Log(name + " - Count : " + count);
		
		//rigidbody.AddForce(new Vector3(Random.Range(-2f,2f),Random.Range(-2f,2f),Random.Range(-2f,2f)));
		int iterations = Random.Range(0,10);
		for(int i =0; i < iterations; i++) {
			Debug.Log("test");
		}
		
		count++;*/
		
		
		
		if(numberOfAgentWhoEmitedInfluence < numberOfAgent) {
			//Debug.Log(name + " - Perception !");
			
			Debug.Log(name + " - Emit Influence !");
			
			takeRandTime();	
			
			numberOfAgentWhoEmitedInfluence++;
		}
		else if (numberOfAgentWhoEmitedInfluence == numberOfAgent && numberOfAgentWhoAppliedAction < numberOfAgent) {
			
			Debug.Log(name + " - Apply Influence !");
			
			takeRandTime();
			
			numberOfAgentWhoAppliedAction++;
		}
		else {
			numberOfAgentWhoEmitedInfluence = 0;
			numberOfAgentWhoAppliedAction = 0;		
		}
		
		
		
		//Debug.Log(name + " - End !");
	}
	
	void takeRandTime() {
	
		int iterations = Random.Range(0,3);
		for(int i =0; i < iterations; i++) {
			Debug.Log("");
		}
	}
}

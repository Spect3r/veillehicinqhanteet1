using UnityEngine;
using System.Collections;

public class testSync : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		//Debug.Log(name + " - Start !");
		
		/*Debug.Log(name + " - Count : " + count);
		
		//rigidbody.AddForce(new Vector3(Random.Range(-2f,2f),Random.Range(-2f,2f),Random.Range(-2f,2f)));
		int iterations = Random.Range(0,10);
		for(int i =0; i < iterations; i++) {
			Debug.Log("test");
		}
		
		count++;*/
		
		
		
		if(Simulateur.state == false) {
			//Debug.Log(name + " - Perception !");
			
			Debug.Log(name + " - Emit Influence !");
			
			//takeRandTime();
		}
		else {
			
			Debug.Log(name + " - Apply Influence !");
			
			//takeRandTime();
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

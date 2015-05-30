using UnityEngine;
using System.Collections;

public class Ant : Insect {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void goToClosestGate(){
		GameObject closestGate = GetClosestObject("Gate");
		transform.position = Vector3.MoveTowards(transform.position, closestGate.transform.position, 0.03f);
		if (transform.position == closestGate.transform.position) {
			if(closestGate.name == "GateA"){
				transform.position = gateB.transform.position;
				behaviour = "OK";
			} else {
				transform.position = gateA.transform.position;
				behaviour = "OK";
			}
			
		}
	}

	public bool isEnemy(){
	
	}

	public bool isFood(){
		
	}
}

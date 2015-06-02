using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Queen : AbstractAgent {

	private int bornTime = 10;
	private int timer = 0;
	public GameObject cocoon;

	// Use this for initialization
	void Start () {
		InvokeRepeating("born",5,bornTime);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void born(){
		Instantiate (cocoon, this.transform.position, this.transform.rotation);
	}

	Collider2D[] getPerception(){
		Collider2D[] perceptions = Physics2D.OverlapCircleAll(transform.position, 3f);
	}
	
	List<Action> makeDecision(Collider2D[] perceptions){
		List<Action> actions;
		foreach (Collider2D collider in perceptions) {
			if(timer>=bornTime)
			{
				timer+=1;
			}else{
				born ();
				timer = 0;
			}
		}
	}
}

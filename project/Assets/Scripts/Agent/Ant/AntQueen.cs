using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AntQueen : Ant {

	/*private int bornTime = 10;
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
	}*/
	
	protected override Collider2D[] getPerception(){
		return Physics2D.OverlapCircleAll(this.transform.position, 3f);
	}
	
	protected override List<Action> makeDecision(Collider2D[] perceptions){
		List<Action> actions = new List<Action>();
		return actions;
	}
	
	protected override Vector2 applyAction(List<Action> actions) {
		return new Vector2();
	}
	protected override void move(Vector2 direction) {
		
	}
}

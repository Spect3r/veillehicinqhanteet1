using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AntCocoon : Ant {

	/*public GameObject worker;
	public GameObject soldier;
	public GameObject nurse;

	// Use this for initialization
	void Start () {
		Invoke ("born", 10);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void born(){
		int number = Random.Range (0, 2);
		switch (number) {
		case 0:
			Debug.Log ("A worker is born");
			Instantiate (worker, this.transform.position, this.transform.rotation);
			Destroy(gameObject);
			break;
		case 1:
			Debug.Log ("A soldier is born");
			Instantiate (soldier, this.transform.position, this.transform.rotation);
			Destroy(gameObject);
			break;
		case 2:
			Debug.Log ("A nurse is born");
			Instantiate (nurse, this.transform.position, this.transform.rotation);
			Destroy(gameObject);
			break;
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

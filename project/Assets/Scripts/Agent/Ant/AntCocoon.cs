using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AntCocoon : Ant {

	public GameObject worker;
	public GameObject soldier;
	//public GameObject nurse;

	private int timer = 0;
	private int bornTime = 100;
	
	/*protected override void initialisation() {
		worker.GetComponent<AntWorker>().setIsHome(true);
	}*/
	
	void born(){
		int number = Random.Range (0, 2);
		switch (number) {
		case 0:
			//Debug.Log ("A worker is born");
			Instantiate (worker.gameObject, this.transform.position, this.transform.rotation);			
			Statistics.addInsect("AntWorker");
			Destroy(gameObject);
			break;
		case 1:
			//Debug.Log ("A soldier is born");
			Instantiate (soldier, this.transform.position, this.transform.rotation);			
			Statistics.addInsect("AntSoldier");
			Destroy(gameObject);
			break;
		/*case 2:
			Debug.Log ("A nurse is born");
			Instantiate (nurse, this.transform.position, this.transform.rotation);
			Destroy(gameObject);
			break;*/
		}
	}
	
	protected override Collider2D[] getPerception(){
		return Physics2D.OverlapCircleAll(this.transform.position, 3f);
	}
	
	protected override List<Action> makeDecision(Collider2D[] perceptions){
		List<Action> actions = new List<Action>();

		if(timer<=bornTime)
		{
			timer+=1;
			actions.Add(new Action("wandering", null));
		}else{
			actions.Add(new Action("born", null));
			timer = 0;
		}
		return actions;
	}
	
	protected override Vector2 applyAction(List<Action> actions) {
		Vector2 direction = new Vector2 (); // = new Vector2 (1f,1f);
		
		foreach(Action action in actions)
		{
			switch(action.getBehaviour())
			{	
			case "wandering" :
				direction += this.wanderingBehaviour.run(this.gameObject);
				break;
			case "born" :
				this.born();
				break;
			}
		}
		return direction;
	}
	protected override void move(Vector2 direction) {
		
	}
}

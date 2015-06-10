using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TermiteCocoon : Termite {
	
	public GameObject worker;
	public GameObject soldier;
	
	private int timer = 0;
	private int bornTime = 100;
	
	
	void born(){
		int number = Random.Range (0, 2);
		switch (number) {
		case 0:
			Instantiate (worker.gameObject, this.transform.position, this.transform.rotation);			
			Statistics.addInsect(worker.tag);
			Destroy(gameObject);
			break;
		case 1:
			Instantiate (soldier, this.transform.position, this.transform.rotation);			
			Statistics.addInsect(soldier.tag);
			Destroy(gameObject);
			break;
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
		Vector2 direction = new Vector2 ();
		
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

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TermiteQueen : Termite {
	
	private int bornTime = 100;
	private int timer = 0;
	public GameObject cocoon;
	
		
	protected override Collider2D[] getPerception(){
		return Physics2D.OverlapCircleAll(this.transform.position, 3f);
	}
	
	protected override List<Action> makeDecision(Collider2D[] perceptions){
		List<Action> actions = new List<Action>();		
		
		if(timer<=bornTime) {
			timer+=1;
		}
		else {
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
			case "seek" :
				direction += this.seekBehaviour.run(this.gameObject, action.getTarget());
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
	
	
	private void born() {
		//Debug.Log(this.tag+ " : " +warehouse.GetComponent<Warehouse>().getFoodQuantity());
	
		if(warehouse.GetComponent<Warehouse>().getFoodQuantity() > 5)
		{
			Vector3 randPosition = Random.insideUnitCircle.normalized * 2;
			Instantiate (cocoon, this.transform.position + randPosition, Quaternion.identity);
			
			warehouse.GetComponent<Warehouse>().setFoodQuantity(-5);
		}		
	}
}

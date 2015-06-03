using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AntSoldier : Ant {
	
	/*void attack(Insect target){
		target.life -= this.strength;
	}

	void isPheromone(){

	}

	Collider2D[] getPerception(){
		return Physics2D.OverlapCircleAll(this.transform.position, 3f);
	}
	
	
	
	List<Action> makeDecision(Collider2D perceptions){
		List<Action> actions;
		foreach(Collider2D collider in perceptions){
			GameObject gameObject = collider.gameObject;
			if(isEnemy(gameObject)){
				actions.Add(new Action("attack", collider));
				actions.Add(new Action("putPheromone", null));
			}
			else{
					if(isPheromone(collider)){
						actions.Add(new Action("seek", collider));
					}else{
						actions.Add(new Action("wandering", null));
					}	
			}
	
		}

	}

	Vector2 applyAction(List<Action> actions)
	{
		Vector2 direction = new Vector2 ();
		foreach(Action action in actions)
		{
			if(action.getBehaviour() == "seek")
			{
				direction += SeekBehaviour.run(action.getTarget());
			}
			if(action.getBehaviour() == "flee")
			{
				direction += FleeBehaviour.run(action.getTarget());
			}
			if(action.getBehaviour() == "wandering")
			{
				direction += Wandering.run();
			}
			if(action.getBehaviour() == "teleportation")
			{
				this.transform.position = gateB.transform.position;
			}
			if(action.getBehaviour() == "putPheromone")
			{
				this.putPheromone();
			}
			if(action.getBehaviour() == "deletePheromone")
			{
				this.deletePheromone();
			}
		}
		return direction;
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
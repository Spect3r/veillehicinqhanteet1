using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpiderWander : Spider {

	/*Collider2D getPerception(){
		Collider2D[] perceptions = Physics2D.OverlapCircleAll(transform.position, 3f);
	}
	
	List<Action> makeDecision(Collider2D[] perceptions){
		List<Action> actions;
		foreach(Collider2D collider in perceptions){
			// if there is an enemy in field of view
			if(isEnemy(collider))
			{
				//attack
				actions.Add(new Action("attack", collider));
			}
			else
			{
				//if there is a gate in field of view
				if(isGate(collider.gameObject))
   			    {
					if(collider.gameObject.transform.position - this.transform.position <= radius)
						//enter in the colony
						actions.Add(new Action("teleportation", collider));
					else
						//go to the gate
						actions.Add(new Action("seek", collider));
				}
				else 
				{
					//else wandering
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

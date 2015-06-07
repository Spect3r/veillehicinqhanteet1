using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpiderWanderer : Spider {

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

		List<GameObject> enemies = new List<GameObject>();

		foreach(Collider2D collider in perceptions){
			if(isEnemy(collider.gameObject)){
				enemies.Add(collider.gameObject);
			}
		}
		//if there is some enemies in the field of view
		if(enemies.Count > 0) 
		{
			GameObject enemy = this.getClosestEntity(enemies);
			if(Vector2.Distance(this.transform.position, enemy.transform.position) < 0.3f){
				actions.Add(new Action("attack", enemy));
			}					
			else {
				actions.Add(new Action("seek", enemy));
			}
		}
		else
		{
			actions.Add(new Action("wandering", null));
		}
		return actions;
	}

	protected override Vector2 applyAction(List<Action> actions)
	{
		Vector2 direction = new Vector2 (); // = new Vector2 (1f,1f);
			
		foreach(Action action in actions)
		{
			switch(action.getBehaviour())
			{
			case "attack" :
				if(action.getTarget().tag == "AntWorker")
				{
					action.getTarget().GetComponent<AntWorker>().takeDamage(this.strength);
				}
				else if(action.getTarget().tag == "AntSoldier")
					action.getTarget().GetComponent<AntSoldier>().takeDamage(this.strength);
				else
					Debug.Log("Je ne reconnais pas cet ennemi");
				break;
			case "wandering" :
				direction += this.wanderingBehaviour.run(this.gameObject);
				break;
			case "seek" :
				direction += this.seekBehaviour.run(this.gameObject, action.getTarget());
				break;
			}
		}
		return direction;
	}

	protected override void move(Vector2 direction) {

		// Kinematic movement
		rigidbody2D.velocity = direction.normalized * speed;
		
		// Orientation		
		if (rigidbody2D.velocity.magnitude > 0) {
				Vector3 referenceForward = new Vector3 (-1, 0, 0);			
				float angle = Vector3.Angle (referenceForward, direction);			
				float sign = Mathf.Sign (Vector3.Dot (new Vector3 (0, 1, 0), direction));			
				transform.rotation = Quaternion.Euler (new Vector3 (0, 0, angle * -sign));
		}
	}
}

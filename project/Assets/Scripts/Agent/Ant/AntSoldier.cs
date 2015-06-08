using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AntSoldier : Ant {
	
	protected override Collider2D[] getPerception(){
		List<Collider2D> perceived = new List<Collider2D>();
		
		// Visual Perception
		perceived.AddRange(Physics2D.OverlapCircleAll(this.transform.position, 4f, 1 << 0));
		
		// Collision Perception
		perceived.AddRange(Physics2D.OverlapCircleAll(this.transform.position, 0.5f, 1 << 8));
		
		// Pheromone Perception
		perceived.AddRange(Physics2D.OverlapCircleAll(this.transform.position, 40f, 1 << 9));		
		
		return perceived.ToArray();
	}
	
	protected override List<Action> makeDecision(Collider2D[] perceptions){
		List<Action> actions = new List<Action>();
		
		List<GameObject> enemies = new List<GameObject>();
		List<GameObject> food = new List<GameObject>();
		//List<GameObject> pheromone = new List<GameObject>();
		
		List<Collider2D> border = new List<Collider2D>();
		
		foreach(Collider2D collider in perceptions){
			if(isEnemy(collider.gameObject)){
				enemies.Add(collider.gameObject);
			}
			if(isFood(collider.gameObject)){
				food.Add(collider.gameObject);
			}
			/*if(isPheromone(collider.gameObject)){
				ennemy.Add(collider.gameObject);
			}*/
			
			if(collider.gameObject.tag == "Border") {
				border.Add(collider);
			}
		}
		
		if(border.Count > 0) {
			actions.Add(new Action("avoidCollision", null));
		}
		else {
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
		}
		return actions;
	}
	
	protected override Vector2 applyAction(List<Action> actions) {
		Vector2 direction = new Vector2 (); // = new Vector2 (1f,1f);
		
		foreach(Action action in actions)
		{
			switch(action.getBehaviour())
			{
			case "attack" :
				if(action.getTarget().tag == "SpiderWanderer")
				{
					action.getTarget().GetComponent<SpiderWanderer>().takeDamage(this.strength);
				}
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
			
			if(action.getBehaviour() == "avoidCollision")
			{
				
				Vector2 referenceForward = new Vector2(-1,0);	
				Vector2 directionFromRotation = this.transform.rotation * referenceForward;
				
				if(!isInCollision)
					direction += (Vector2) ( Quaternion.AngleAxis(180, this.transform.forward) * directionFromRotation );
				else
					direction += directionFromRotation;
				
				isInCollision = true;
			}
			else {
				isInCollision = false;
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
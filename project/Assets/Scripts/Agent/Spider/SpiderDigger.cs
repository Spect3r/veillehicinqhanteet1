using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpiderDigger : Spider {

	public GameObject hole;
	private bool isDigging = true;
	
	protected override void initialisation () {		
		this.hole = Instantiate(hole,transform.position,transform.rotation) as GameObject;
		this.animation = this.gameObject.GetComponent<Animator>();
	}

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
		
		List<Collider2D> border = new List<Collider2D>();

		foreach (Collider2D collider in perceptions) {
			if (isEnemy (collider.gameObject)) {
				enemies.Add (collider.gameObject);
			}
			
			if(collider.gameObject.tag == "Border") {
				border.Add(collider);
			}
		}
		
		if(border.Count > 0) {
			actions.Add(new Action("avoidCollision", null));
		}
		else {
			//if there is some enemies in the field of view
			if (enemies.Count > 0) {
				GameObject enemy = this.getClosestEntity (enemies);
				if (Vector2.Distance (this.transform.position, enemy.transform.position) < 0.3f) {
						actions.Add (new Action ("attack", enemy));
				} else {
						actions.Add (new Action ("seek", enemy));
				}
			} 
			else 
			{
				if (Vector2.Distance (this.transform.position, hole.transform.position) < 0.3f)
				{
					if (isDigging == true) {
						//Debug.Log("Construct the hole");
						actions.Add(new Action("constructHole", null));
					}
				}
				else
				{
					actions.Add (new Action ("seek", this.hole));
				}	
			}
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
			case "constructHole" :
				this.constructHole();
				break;
			case "seek" :
				direction += this.seekBehaviour.run(this.gameObject, action.getTarget());
				break;
			}
			
			if(action.getBehaviour() == "avoidCollision")
			{
				Vector2 referenceForward = new Vector2(0,1);	
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
			Vector3 referenceForward = new Vector3 (0, 1, 0);			
			float angle = Vector3.Angle (referenceForward, direction);	
			float sign = Mathf.Sign (Vector3.Dot (new Vector3 (1, 0, 0), direction));			
			transform.rotation = Quaternion.Euler (new Vector3 (0, 0, angle * -sign));
		}
		
		// Animation
		if(animation != null) {
			if(rigidbody2D.velocity.magnitude > 0 || isDigging)
				animation.SetBool("moving", true);
			else
				animation.SetBool("moving", false);
		}
	}
	
	private void constructHole()
	{
		if(hole.transform.localScale.x >= 6f && hole.transform.localScale.y >= 6f)
		{
			isDigging = false;
		}
		else
		{
			//Debug.Log("+0.5");
			hole.transform.localScale += new Vector3(0.03f,0.03f,0);
		}
	}

}

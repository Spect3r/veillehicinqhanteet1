using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Insect : AbstractAgent {
	
	// Caracteristics
	public int speed;
	public int life;
	public int strength;
	
	// State
	protected bool isInCollision = false;
	
	// Behaviour
	protected SeekBehaviour seekBehaviour = new SeekBehaviour();
	protected FleeBehaviour fleeBehaviour = new FleeBehaviour();
	protected Wandering wanderingBehaviour = new Wandering();
	
	// Animation
	protected Animator animation;
	
	
	bool isGate(GameObject gameObject) {
		if (gameObject.tag == "Gate")
			return true;
		else
			return false;
	}
	
	protected GameObject getClosestEntity(List<GameObject> entities) {
		GameObject closestEntity = null;
		
		foreach (GameObject entity in entities) {
			if (closestEntity != null) {
				if (Vector2.Distance (closestEntity.transform.position, this.gameObject.transform.position) > Vector2.Distance (entity.transform.position, this.gameObject.transform.position)) {
					closestEntity = entity;
				}
			} else {
				closestEntity = entity;
			}
		}
		return closestEntity;
	}
	
	public void takeDamage(int damage)
	{
		this.life -= damage;
		
		if(life <= 0)
		{
			Destroy(this.gameObject);
		}
	}
}

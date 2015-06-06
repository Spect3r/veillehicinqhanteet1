using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public sealed class AntWorker : Ant {

	/*public GameObject warningPheromone;
	public GameObject foodPheromone;*/
	
	private bool carryingFood = false;
	private bool isHome = false;
	
	protected override void initialisation() {
		this.animation = this.gameObject.GetComponent<Animator>();
	}

	/*public void findFood(){
		GameObject closestFood = GetClosestObject ("Food");
		//Debug.Log("Closest Object is " + closestFood.name);
		this.target = closestFood;
		int foodPoint = closestFood.gameObject.GetComponent<Food> ().foodPoint;
		transform.position = Vector3.MoveTowards(transform.position, target.transform.position, 0.03f);
		if (target.transform.position == this.transform.position) {
			if(foodPoint <= 0){
				Destroy(target);
			} else {
				foodPoint = foodPoint - 1;}
			InvokeRepeating ("putPheromone", 0, 2);
			behaviour = "GoToQueen";
			goToQueen();
		}
	}

	public void goToQueen (){
		GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Queen");
		GameObject queen = objectsWithTag [0];
		this.target = queen;
		transform.position = Vector3.MoveTowards(transform.position, target.transform.position, 0.03f);
		if (target.transform.position == this.transform.position) {
			CancelInvoke("putPheromone");
			behaviour = "FindFood";
		}
	}

	public void putPheromone(){
		Instantiate (foodPheromone, this.transform.position, Quaternion.identity);
	}

	public void deletePheromone(GameObject pheromone)
	{
		Destroy (pheromone);
	}*/
	

	protected override Collider2D[] getPerception() {
		return Physics2D.OverlapCircleAll(this.transform.position, 4f);
	}



	protected override List<Action> makeDecision(Collider2D[] perceptions){
		List<Action> actions = new List<Action>();
		
		List<GameObject> ennemy = new List<GameObject>();
		List<GameObject> food = new List<GameObject>();
		//List<GameObject> pheromone = new List<GameObject>();
		
		foreach(Collider2D collider in perceptions){
			if(isEnemy(collider.gameObject)){
				ennemy.Add(collider.gameObject);
			}
			if(isFood(collider.gameObject)){
				food.Add(collider.gameObject);
			}
			/*if(isPheromone(collider.gameObject)){
				ennemy.Add(collider.gameObject);
			}*/
		}
		
		/*if(true) {
			actions.Add(new Action("seek", homeIn));
		}*/
		if(ennemy.Count > 0) 
		{
			foreach(GameObject target in ennemy)
				actions.Add(new Action("flee", target));
			
			//actions.Add(new Action("putPheromone", warningPheromone));
		}
		else
		{
			if(carryingFood == true){
				if(isHome == true) {				
					if(Vector2.Distance(this.transform.position, warehouse.transform.position) < 0.3f){
						actions.Add(new Action("dropFood", null));
					}					
					else {
						actions.Add(new Action("seek", warehouse));
					}
				}
				else {				
					if(Vector2.Distance(this.transform.position, homeIn.transform.position) < 0.3f){
						actions.Add(new Action("teleportationIn", null));
					}
					else{
						actions.Add(new Action("seek", homeIn));
					}
				}
			}
			else{
				if(isHome == true) {
					if(Vector2.Distance(this.transform.position, homeOut.transform.position) < 0.3f){
						actions.Add(new Action("teleportationOut", null));
					}
					else{
						actions.Add(new Action("seek", homeOut));
					}
				}
				else {
					if(food.Count > 0){
						GameObject nearestFood = null;
						
						foreach(GameObject target in food) {
							if(nearestFood != null) {
								if(Vector2.Distance(nearestFood.transform.position, this.gameObject.transform.position) > Vector2.Distance(target.transform.position, this.gameObject.transform.position)) {
									nearestFood = target;
								}
							}
							else {
								nearestFood = target;
							}
						}
						
						if(Vector2.Distance(nearestFood.transform.position, this.transform.position) < 0.3f){
							actions.Add(new Action("takeFood", nearestFood));
							//actions.Add(new Action("putPheromone", foodPheromone));
						}
						else{
								
							actions.Add(new Action("seek", nearestFood));
						}
					}
					else{
						
						actions.Add(new Action("wandering", null));
					
						/*if(isPheromone(collider.gameObject)){
							if(this.transform.position == collider.transform.position){
								actions.Add(new Action("deletePheromone", collider.gameObject));
							}
							else{
								//actions.Add(new Action("seek", foodPheromone));
							}
						}
						else{
							//actions.Add(new Action("wandering", null));
						}*/
					}
				}
			}
		}
		
		return actions;
	}

	protected override Vector2 applyAction(List<Action> actions)
	{
		Vector2 direction = new Vector2 (); // = new Vector2 (1f,1f);
		
		/*bool seekDone = false;
		bool fleeDone = false;
		bool wanderingDone = false;*/
		
		foreach(Action action in actions)
		{
			// peut mettre un switch à la place
			if(action.getBehaviour() == "seek") // && !seekDone)
			{
				direction += this.seekBehaviour.run(this.gameObject, action.getTarget());
				//seekDone = true;
			}
			if(action.getBehaviour() == "flee") // && !fleeDone)
			{
				direction += this.fleeBehaviour.run(this.gameObject, action.getTarget());
				//fleeDone = true;
			}
			if(action.getBehaviour() == "wandering") // && !wanderingDone)
			{
				direction += this.wanderingBehaviour.run(this.gameObject);
				//wanderingDone = true;
			}
			if(action.getBehaviour() == "takeFood")
			{
				if(action.getTarget() != null) {
					action.getTarget().GetComponent<Food>().takeFood();
					carryingFood = true;
				}
				else {
					Debug.Log("You can't eat that if there is nothing left !");
				}
			}
			if(action.getBehaviour() == "dropFood")
			{
				carryingFood = false;
			}
			if(action.getBehaviour() == "teleportationIn")
			{
				this.transform.position = homeOut.transform.position;
				this.isHome = true;
			}
			if(action.getBehaviour() == "teleportationOut")
			{
				this.transform.position = homeIn.transform.position;
				this.transform.rotation = Quaternion.AngleAxis(Random.Range(-180f,180f), new Vector3(0f,0f,1f));
				this.isHome = false;
			}
			/*if(action.getBehaviour() == "putPheromone")
			{
				this.putPheromone();
			}
			if(action.getBehaviour() == "deletePheromone")
			{
				this.deletePheromone();
			}*/
		}
		return direction;
	}

	protected override void move(Vector2 direction)
	{
		// Kinematic movement
		rigidbody2D.velocity = direction.normalized * speed;
		
		// Orientation		
		if(rigidbody2D.velocity.magnitude > 0) {
			Vector3 referenceForward = new Vector3(-1,0,0);			
			float angle = Vector3.Angle(referenceForward, direction);			
			float sign = Mathf.Sign(Vector3.Dot(new Vector3(0,1,0),direction));			
			transform.rotation = Quaternion.Euler(new Vector3(0,0,angle * -sign));
		}
		
		// Animation
		if(animation != null) {
			if(rigidbody2D.velocity.magnitude > 0)
				animation.SetBool("moving", true);
			else
				animation.SetBool("moving", false);
		}
	}
		

}




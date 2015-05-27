using UnityEngine;
using System.Collections;

public class Worker : Ant {

	public GameObject target;
	public GameObject pheromone;

	private GameObject[] gates;

	void Awake(){
		gates = GameObject.FindGameObjectsWithTag ("Gate");
	}

	// Use this for initialization
	void Start () {
		findFood ();
	}
	
	// Update is called once per frame
	void Update () {
		if (behaviour == "GoToQueen") {
			goToQueen();
		} else {
			findFood ();
		}
		if (behaviour != "OK") {
			goToQueen();	
		}


		if (target.transform.position == this.transform.position) {
			behaviour = "SearchFood";
			findFood();
		}
	}

	public override void findFood(){
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
				//InvokeRepeating ("putPheromone", 0, 2);
				behaviour = "GoToQueen";
				goToQueen();
		}
	}

	public override void goToQueen (){
		GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Queen");
		GameObject queen = objectsWithTag [0];
		this.target = queen;
		transform.position = Vector3.MoveTowards(transform.position, target.transform.position, 0.03f);
		if (target.transform.position == this.transform.position) {
			CancelInvoke("putPheromone");
			behaviour = "FindFood";
		}
		ant_pheromone.setMessage ("food");
		GameObject clone = (GameObject) Instantiate (pheromone);
		clone.renderer.material.SetColor("_SpecColor", Color.red);

	}

	public override void putPheromone(){
		Instantiate (pheromone, this.transform.position, Quaternion.identity);
	}

	public GameObject GetClosestObject(string tag)
	{
		//find all gameObjects with tag "tag"
		GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag(tag);
		GameObject closestObject = null;
		foreach (GameObject obj in objectsWithTag)
		{
			if(!closestObject)
			{
				closestObject = obj;
			}
			//compares distances
			if(Vector3.Distance(transform.position, obj.transform.position) <= Vector3.Distance(transform.position, closestObject.transform.position))
			{
				closestObject = obj;
			}
		}
		return closestObject;
	}

	public override void goToClosestGate(){
		GameObject closestGate = GetClosestObject("Gate");
		transform.position = Vector3.MoveTowards(transform.position, closestGate.transform.position, 0.03f);
		if (transform.position == closestGate.transform.position) {
			if(closestGate.name == "GateA"){
				transform.position = gateB.transform.position;
				behaviour = "OK";
			} else {
				transform.position = gateA.transform.position;
				behaviour = "OK";
			}
					
		}
	}

	public override void followPheromone ()
	{
		throw new System.NotImplementedException ();
	}
}

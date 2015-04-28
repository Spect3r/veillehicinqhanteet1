using UnityEngine;
using System.Collections;

public class Worker : MonoBehaviour {

	public GameObject target;
	public string behaviour;
	public GameObject pheromone;

	// Use this for initialization
	void Start () {
		//findFood ();
	}
	
	// Update is called once per frame
	void Update () {
		if (behaviour == "GoToQueen") {
			goToQueen ();
		} else {
			findFood ();
		}


		/*if (target.transform.position == this.transform.position) {
			behaviour = "SearchFood";
			findFood();
		}*/
	}

	public void findFood(){
		GameObject closestFood = GetClosestObject ("Food");
		//Debug.Log("Closest Object is " + closestFood.name);
		this.target = closestFood;
		transform.position = Vector3.MoveTowards(transform.position, target.transform.position, 0.03f);
		if (target.transform.position == this.transform.position) {
			//Destroy(target);
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
		}
	}

	public void putPheromone(){
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
}

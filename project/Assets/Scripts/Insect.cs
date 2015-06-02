using UnityEngine;
using System.Collections;

public class Insect : MonoBehaviour {

	public int speed;
	public int life;
	public GameObject gateA;
	public GameObject gateB;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}

	/*public void randomMove(){

		transform.Translate(1,0,0);
		
	}*/

	bool isGate(GameObject gameObject)
	{
		if (gameObject.tag == "Gate")
						return true;
				else
						return false;
	}

	public void followPheromone(){

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

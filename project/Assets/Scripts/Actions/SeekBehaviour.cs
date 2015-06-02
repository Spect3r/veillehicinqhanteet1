using UnityEngine;
using System.Collections;

public class SeekBehaviour : MonoBehaviour {
	

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		//transform.position = Vector3.MoveTowards(transform.position, target.transform.position, 0.03f);
	}

	public Vector2 run(GameObject target)
	{
		Vector2 direction = target.transform.position - this.transform.position;
		direction.Normalize ();
	}
}
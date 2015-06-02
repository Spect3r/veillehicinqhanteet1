using UnityEngine;
using System.Collections;

public class FleeBehaviour : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	Vector2 run(GameObject target)
	{
		Vector2 direction = this.transform.position - target.transform.position;
		direction.Normalize ();
	}
}

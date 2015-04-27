using UnityEngine;
using System.Collections;

public class SeekBehaviour : MonoBehaviour {

	public GameObject target;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		transform.position = Vector3.MoveTowards(transform.position, target.transform.position, 0.03f);
		
	}
}
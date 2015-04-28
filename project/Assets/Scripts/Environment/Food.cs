using UnityEngine;
using System.Collections;

public class Food : MonoBehaviour {

	public int foodPoint;

	/*public Food()
	{
		foodPoint = 10;
	}*/

	void Awake() {
		foodPoint = 10;
	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		Debug.Log (foodPoint);
	
	}
}

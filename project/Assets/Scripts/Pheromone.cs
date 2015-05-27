using UnityEngine;
using System.Collections;

public class Pheromone : MonoBehaviour {

	private float timer = 0.0f;
	private string message ="";

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer >= 10.0f)
			Destroy (gameObject);
	}
	public void setMessage(string m){
		this.message = m;
	}
	public string getMessage(){
		return this.message;
	}

}

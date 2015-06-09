using UnityEngine;
using System.Collections;

public class Food : MonoBehaviour {

	public int foodAmount;

	void Awake() {
		foodAmount = 10;
	}
	
	public void takeFood() {
		foodAmount--;
		
		if(foodAmount <= 0) {
			GameObject.Destroy(this.gameObject);
		}
	}
}

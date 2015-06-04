using UnityEngine;
using System.Collections;

public class Food : MonoBehaviour {

	public int foodPoint;

	void Awake() {
		foodPoint = 10;
	}
	
	public void takeFood() {
		foodPoint--;
	}
}

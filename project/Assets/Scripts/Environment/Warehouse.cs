using UnityEngine;
using System.Collections;

public class Warehouse : MonoBehaviour {

	private int foodQuantity = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void addFood()
	{
		foodQuantity += 1;
	}

	public int getFoodQuantity()
	{
		return this.foodQuantity;
	}

	public void setFoodQuantity(int foodQuantity)
	{
		this.foodQuantity += foodQuantity;
	}
	
}
